import React, { useState, useEffect } from 'react';
import '../styles/BookSearchBar.css'; 

const BookSearchBar = () => {
  const [query, setQuery] = useState('');
  const [results, setResults] = useState([]);

  useEffect(() => {
    const searchDelayTimer = setTimeout(() => {
      if (query.trim()) {
        fetch(`http://localhost:5000/books/search?title=${encodeURIComponent(query)}&maxResults=5`)
          .then((res) => res.json())
          .then((data) => setResults(data))
          .catch((err) => {
            console.error('Search failed:', err);
            setResults([]);
          });
      } else {
        setResults([]);
      }
    }, 300); // debounce delay

    return () => clearTimeout(searchDelayTimer);
  }, [query]);

  return (
    <div className="search-container">
      <input
        type="text"
        placeholder="Search books by title..."
        value={query}
        onChange={(e) => setQuery(e.target.value)}
      />

      {results.length > 0 && (
        <ul className="search-results">
          {results.map((book) => (
            <li key={book.id}>
              <strong>{book.title}</strong> ({book.publicationYear})
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default BookSearchBar;
