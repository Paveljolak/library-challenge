import React, { useState, useEffect } from 'react';
import '../styles/BookList.css';
import BookForm from './BookForm.js';

const BooksList = () => {
  const [books, setBooks] = useState([]);
  const [authors, setAuthors] = useState({});
  const [page, setPage] = useState(1);
  const [hasNextPage, setHasNextPage] = useState(true);
  const [isAdding, setIsAdding] = useState(false);
  const [bookToEdit, setBookToEdit] = useState(null);
  const [error, setError] = useState(null);
  const pageSize = 10;

  useEffect(() => {
    fetchBooks(page);
    fetchAuthors(); // Fetch and cache all authors on initial load
  }, [page]);

  const fetchAuthors = async () => {
    try {
      const response = await fetch('http://localhost:5000/authors');
      if (!response.ok) throw new Error('Failed to fetch authors');
      const data = await response.json();
      const authorMap = {};
      data.forEach((author) => {
        authorMap[author.id] = author.name;
      });
      setAuthors(authorMap);
    } catch (err) {
      setError(err.message);
    }
  };

  const fetchBooks = async (currentPage) => {
    try {
      const response = await fetch(`http://localhost:5000/books?page=${currentPage}&pageSize=${pageSize}`);
      if (!response.ok) throw new Error('Failed to fetch books');
      const data = await response.json();

      if (data.length === 0 && currentPage > 1) {
        setPage(currentPage - 1);
        return;
      }

      setBooks(data);
      checkNextPage(currentPage + 1);
    } catch (err) {
      setError(err.message);
    }
  };

  const checkNextPage = async (nextPage) => {
    try {
      const response = await fetch(`http://localhost:5000/books?page=${nextPage}&pageSize=${pageSize}`);
      if (!response.ok) throw new Error('Failed to check next page');
      const data = await response.json();
      setHasNextPage(data.length > 0);
    } catch (err) {
      setError(err.message);
    }
  };

  const handlePageChange = (newPage) => {
    if (newPage < 1) return;
    setPage(newPage);
  };

  const handleAddBook = () => {
    setIsAdding(true);
    setBookToEdit(null);
  };

  const handleEditBook = (book) => {
    setIsAdding(true);
    setBookToEdit(book);
  };

  const handleSaveBook = async (bookData) => {
    const url = bookToEdit
      ? `http://localhost:5000/books/${bookToEdit.id}`
      : `http://localhost:5000/books`;
    const method = bookToEdit ? 'PUT' : 'POST';

    try {
      const response = await fetch(url, {
        method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(bookData),
      });

      if (!response.ok) throw new Error('Failed to save book');
      setIsAdding(false);
      setBookToEdit(null);
      fetchBooks(page);
    } catch (err) {
      setError(err.message);
    }
  };

  const handleCancel = () => {
    setIsAdding(false);
    setBookToEdit(null);
  };

  const handleDeleteBook = async (bookId) => {
    const confirmed = window.confirm('Are you sure you want to delete this book?');
    if (!confirmed) return;

    try {
      const response = await fetch(`http://localhost:5000/books/${bookId}`, {
        method: 'DELETE',
      });

      if (!response.ok) throw new Error('Failed to delete book');
      fetchBooks(page);
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <div>
      <h1>Books List</h1>
      {error && <div className="error">{error}</div>}

      <button onClick={handleAddBook}>Add New Book</button>

      {(isAdding || bookToEdit) && (
        <BookForm
          bookToEdit={bookToEdit}
          onSave={handleSaveBook}
          onCancel={handleCancel}
          authors={authors}
        />
      )}

      <table>
        <thead>
          <tr>
            <th>Title</th>
            <th>Publication Year</th>
            <th>Author</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {books.map((book) => (
            <tr key={book.id}>
              <td>{book.title}</td>
              <td>{book.publicationYear}</td>
              <td>{authors[book.authorId] || 'Unknown Author'}</td>
              <td>
                <button onClick={() => handleEditBook(book)}>Edit</button>
                <button onClick={() => handleDeleteBook(book.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <div className="pagination">
        <button onClick={() => handlePageChange(page - 1)} disabled={page === 1}>
          Prev
        </button>
        <span>Page {page}</span>
        <button onClick={() => handlePageChange(page + 1)} disabled={!hasNextPage}>
          Next
        </button>
      </div>
    </div>
  );
};

export default BooksList;
