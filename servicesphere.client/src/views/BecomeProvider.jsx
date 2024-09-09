import React, { useState } from 'react';
import { Autocomplete } from '@react-google-maps/api';

const BecomeProvider = () => {
  const [address, setAddress] = useState('');
  const [service, setService] = useState('');
  const [documents, setDocuments] = useState(null);
  const [resume, setResume] = useState(null);
  const [motivation, setMotivation] = useState('');

  const handleAddressChange = (e) => {
    setAddress(e.target.value);
  };

  const handleServiceChange = (e) => {
    setService(e.target.value);
  };

  const handleDocumentsChange = (e) => {
    setDocuments(e.target.files[0]);
  };

  const handleResumeChange = (e) => {
    setResume(e.target.files[0]);
  };

  const handleMotivationChange = (e) => {
    setMotivation(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Handle form submission
    console.log({
      address,
      service,
      documents,
      resume,
      motivation,
    });
  };

  return (
    <div className="container mt-5">
      <h2 className="mb-4">Become a Provider</h2>
      <form onSubmit={handleSubmit} className="needs-validation" noValidate>
        <div className="mb-3">
          <h4 className="mb-2">Address</h4>
          <Autocomplete>
            <input
              type="text"
              placeholder="Enter your address"
              value={address}
              onChange={handleAddressChange}
              className="form-control"
            />
          </Autocomplete>
        </div>

        <div className="mb-3">
          <h4 className="mb-2">Service to Provide</h4>
          <select value={service} onChange={handleServiceChange} className="form-select">
            <option value="" disabled>Select a service</option>
            <option value="outdoor">Outdoor Cleaning</option>
            <option value="indoor">Indoor Cleaning</option>
          </select>
        </div>

        <div className="mb-3">
          <h4 className="mb-2">Documents (Certified Copy of ID or Passport)</h4>
          <input
            type="file"
            accept=".pdf,.doc,.docx,.jpg,.png"
            onChange={handleDocumentsChange}
            className="form-control"
          />
        </div>

        <div className="mb-3">
          <h4 className="mb-2">Submit Resume</h4>
          <input
            type="file"
            accept=".pdf,.doc,.docx"
            onChange={handleResumeChange}
            className="form-control"
          />
        </div>

        <div className="mb-3">
          <h4 className="mb-2">Motivation</h4>
          <textarea
            value={motivation}
            onChange={handleMotivationChange}
            placeholder="Write your motivation for becoming a provider..."
            className="form-control"
            rows="4"
          />
        </div>

        <button type="submit" className="btn btn-primary">Submit</button>
      </form>
    </div>
  );
};

export default BecomeProvider;
