import React from 'react';
import BooksList from '../components/BookList.js';
import BookSearchBar from '../components/BookSearchBar';

const Home = () => {
  return (
    <div>
      <h1>Library Management System</h1>
      <div>
      <BookSearchBar />
    </div>
      <BooksList />
    </div>
  );
};

export default Home;
