import React, { useState, useEffect } from 'react';
import '../styles/BookList.css';

const BooksList = () => {
  // State to store books and pagination info
  const [books, setBooks] = useState([]);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [error, setError] = useState(null);

  // Fetch books on page load or when page changes
  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const response = await fetch(`http://localhost:5000/books?page=1&pageSize=15`); // TODO: Fix pagination
        // TODO: Fix pagination here
        if (!response.ok) throw new Error('Failed to fetch books');
        const data = await response.json();
        console.log(data);
        setBooks(data);
      } catch (err) {
        setError(err.message);
      }
    };
    fetchBooks();
  }, [page]);


  // TODO: Needs to be fixed.
  // Handle page change 
  const handlePageChange = (newPage) => {
    if (newPage < 1 || newPage > totalPages) return;
    setPage(newPage);
  };

  return (
    <div>
      <h1>Books List</h1>

      {error && <div className="error">{error}</div>}

      <table>
        <thead>
          <tr>
            <th>Title</th>
            <th>Publication Year</th>
            <th>Author</th>
          </tr>
        </thead>
        <tbody>
          {books.map((book) => (
            <tr key={book.id}>
              <td>{book.title}</td>
              <td>{book.publicationYear}</td>
              <td>{book.authorId}</td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Pagination Controls NEEDS TO BE FIXED*/}
      <div className="pagination">
        <button onClick={() => handlePageChange(page - 1)} disabled={page === 1}>
          Prev
        </button>
        <span>Page {page} of {totalPages}</span>
        <button onClick={() => handlePageChange(page + 1)} disabled={page === totalPages}>
          Next
        </button>
      </div>
    </div>
  );
};

export default BooksList;