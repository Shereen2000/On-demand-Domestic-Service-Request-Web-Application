import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

const EstimateCalculator = ({ selectedService, setEstimatedHours, estimatedHours }) => {
  const [selectedExtras, setSelectedExtras] = useState([]);
  const [bedrooms, setBedrooms] = useState(1);
  const [bathrooms, setBathrooms] = useState(1);

  // Function to handle extra changes
  const handleExtraChange = (extra) => {
    const updatedExtras = selectedExtras.includes(extra)
      ? selectedExtras.filter((e) => e.Id !== extra.Id)
      : [...selectedExtras, extra];

    setSelectedExtras(updatedExtras);
  };

  // Calculate the total estimated hours including extras and room adjustments
  useEffect(() => {
    let totalHours = selectedService.EstHours;

    // Check if the service is "Indoor Cleaning" using Id === 1
    if (selectedService.Id === 1) {
      if (bedrooms > 1) {
        totalHours += (bedrooms - 1) * (25 / 60); // Add 25 minutes per additional bedroom
      }
      if (bathrooms > 1) {
        totalHours += (bathrooms - 1) * (15 / 60); // Add 15 minutes per additional bathroom
      }
    }

    // Add the time for selected extras
    totalHours += selectedExtras.reduce((sum, extra) => sum + extra.EstHours, 0);

    // Update the parent component's estimated hours
    setEstimatedHours(totalHours);
  }, [selectedExtras, bedrooms, bathrooms, selectedService, setEstimatedHours]);

  return (
    <div className="container mt-4 border border-primary rounded p-4">
      <h3 className="mb-3">Estimate Calculator</h3>
      <p className="mb-4">
        Base Service: <strong>{selectedService.Name}</strong> - Estimated Hours: <strong>{selectedService.EstHours}</strong>
      </p>

      {/* Show inputs for bedrooms and bathrooms if the service Id is 1 (Indoor Cleaning) */}
      {selectedService.Id === 1 && (
        <div className="mb-4">
          <div className="mb-3">
            <label className="form-label">Number of Bedrooms:</label>
            <input
              type="number"
              min="1"
              className="form-control"
              value={bedrooms}
              onChange={(e) => setBedrooms(parseInt(e.target.value, 10))}
            />
          </div>
          <div>
            <label className="form-label">Number of Bathrooms:</label>
            <input
              type="number"
              min="1"
              className="form-control"
              value={bathrooms}
              onChange={(e) => setBathrooms(parseInt(e.target.value, 10))}
            />
          </div>
        </div>
      )}

      {/* List of available extras */}
      {selectedService.Extras.length > 0 && (
        <div className="mb-4">
          <h4>Select Extras:</h4>
          {selectedService.Extras.map((extra) => (
            <div key={extra.Id} className="form-check">
              <input
                type="checkbox"
                className="form-check-input"
                id={`extra-${extra.Id}`}
                value={extra.Name}
                onChange={() => handleExtraChange(extra)}
              />
              <label className="form-check-label" htmlFor={`extra-${extra.Id}`}>
                {extra.Name} - {extra.Description} (Est. Hours: {extra.EstHours})
              </label>
            </div>
          ))}
        </div>
      )}

      {/* Display the total estimated hours */}
      <p className="fw-bold">Total Estimated Hours: {estimatedHours}</p>
    </div>
  );
};

export default EstimateCalculator;
