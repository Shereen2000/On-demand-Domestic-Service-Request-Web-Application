import React, { useState, useCallback } from 'react';
import { Autocomplete, useLoadScript } from '@react-google-maps/api';
import 'bootstrap/dist/css/bootstrap.min.css';

const libraries = ['places'];

const BecomeProvider = () => {
  const [address, setAddress] = useState('');
  const [service, setService] = useState('');
  const [documents, setDocuments] = useState(null);
  const [resume, setResume] = useState(null);
  const [motivation, setMotivation] = useState('');
  const [autocomplete, setAutocomplete] = useState(null);

  // Load the Google Maps API
  const { isLoaded } = useLoadScript({
    googleMapsApiKey: import.meta.env.REACT_APP_GOOGLE_MAPS_API_KEY, // Ensure this is defined in your .env file
    libraries,
  });

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

  const onPlaceChanged = () => {
    if (autocomplete) {
      const place = autocomplete.getPlace();
      if (place && place.formatted_address) {
        setAddress(place.formatted_address);
      }
    }
  };

  if (!isLoaded) return <div className="text-center">Loading...</div>;

  return (
    <div className="container mt-5">
      <h2 className="mb-4">Become a Provider</h2>
      <form onSubmit={handleSubmit} className="needs-validation" noValidate>
        <div className="mb-3">
          <h4 className="mb-2">Address</h4>
          <Autocomplete
            onLoad={(auto) => setAutocomplete(auto)}
            onPlaceChanged={onPlaceChanged}
          >
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
