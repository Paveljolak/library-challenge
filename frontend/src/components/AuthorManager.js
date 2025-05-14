import React, { useState } from 'react';
import '../styles/AuthorManager.css';

const AuthorManager = ({ authors, onClose, onAddAuthor }) => {
  const [newAuthorName, setNewAuthorName] = useState('');
  const [dateOfBirth, setDateOfBirth] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();

    const today = new Date().toISOString().split('T')[0];
    if (dateOfBirth > today) {
      alert('Date of birth cannot be in the future.');
      return;
    }

    onAddAuthor({
      name: newAuthorName.trim(),
      dateOfBirth: new Date(dateOfBirth).toISOString(),
    });

    setNewAuthorName('');
    setDateOfBirth('');

    onClose();
  };

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>Add Author</h2>
        <form onSubmit={handleSubmit}>
          <div>
            <label>Name:</label>
            <input
              type="text"
              placeholder="Author name"
              value={newAuthorName}
              onChange={(e) => setNewAuthorName(e.target.value)}
              required
            />
          </div>
          <div>
            <label>Date of Birth:</label>
            <input
              type="date"
              value={dateOfBirth}
              onChange={(e) => setDateOfBirth(e.target.value)}
              required
              max={new Date().toISOString().split('T')[0]}
            />
          </div>
          <div className="modal-actions">
          <button type="submit">Add Author</button>
          <button type="button" onClick={onClose}>Close</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default AuthorManager;
