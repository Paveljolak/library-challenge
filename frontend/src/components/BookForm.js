import React, { useState, useEffect } from 'react';
import '../styles/BookForm.css';

const BookForm = ({ bookToEdit, onSave, onCancel, authors }) => {
  const [title, setTitle] = useState('');
  const [publicationYear, setPublicationYear] = useState('');
  const [authorId, setAuthorId] = useState('');

  useEffect(() => {
    if (bookToEdit) {
      setTitle(bookToEdit.title);
      setPublicationYear(bookToEdit.publicationYear);
      setAuthorId(bookToEdit.authorId);
    } else {
      setTitle('');
      setPublicationYear('');
      setAuthorId('');
    }
  }, [bookToEdit]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const bookData = { title, publicationYear, authorId: parseInt(authorId) };
    onSave(bookData);
  };

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>{bookToEdit ? 'Edit Book' : 'Add New Book'}</h2>
        <form onSubmit={handleSubmit}>
          <div>
            <label>Title:</label>
            <input
              type="text"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              required
            />
          </div>
          <div>
            <label>Publication Year:</label>
            <input
              type="number"
              value={publicationYear}
              onChange={(e) => setPublicationYear(e.target.value)}
              required
            />
          </div>
          <div>
            <label>Author:</label>
            <select
              value={authorId}
              onChange={(e) => setAuthorId(e.target.value)}
              required
            >
              <option value="" disabled>Select an author</option>
              {Object.entries(authors).map(([id, name]) => (
                <option key={id} value={id}>
                  {name}
                </option>
              ))}
            </select>
          </div>
          <div className="modal-actions">
          <button type="submit">{bookToEdit ? 'Update Book' : 'Add Book'}</button>
          <button type="button" onClick={onCancel}>Cancel</button>
          </div>
        </form>
      </div> 
    </div> 
  );
};

export default BookForm;
