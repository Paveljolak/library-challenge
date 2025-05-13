import React, { useState, useEffect } from 'react';
import '../styles/BookList.css';

const BooksList = () => {
  const [books, setBooks] = useState([]);
  const [page, setPage] = useState(1);
  const [hasNextPage, setHasNextPage] = useState(true);
  const [error, setError] = useState(null);
  const pageSize = 10;

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const response = await fetch(`http://localhost:5000/books?page=${page}&pageSize=${pageSize}`);
        if (!response.ok) throw new Error('Failed to fetch books');
        const data = await response.json();
        setBooks(data);
        checkNextPage(page + 1);
      } catch (err) {
        setError(err.message);
      }
    };
    fetchBooks();
  }, [page]);


   const handlePageChange = (newPage) => {
    if (newPage < 1) return;  // Prevent going beyond available pages
    setPage(newPage); 
    };


   // Check the next page for available books
  const checkNextPage = async (nextPage) => {
    const response = await fetch(`http://localhost:5000/books?page=${nextPage}&pageSize=${pageSize}`);
    const data = await response.json();

    // If the next page is empty then we are at the last page.
    if (data.length === 0 ) {
      setHasNextPage(false); // Disable next button
    } else {
      setHasNextPage(true); // Enable next button
    }
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

      {/* Pagination Controls */}
      <div className="pagination">
        <button onClick={() => handlePageChange(page - 1)} disabled={page === 1}>
          Prev
        </button>
        <span>Page {page}</span>
        <button 
          onClick={() => handlePageChange(page + 1)} 
          disabled={!hasNextPage} // Disable next button if no more pages are available
        >
          Next
        </button>
      </div>
    </div>
  );
}; 

export default BooksList;