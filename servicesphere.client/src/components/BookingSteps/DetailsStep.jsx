import React, { useState, useEffect } from 'react';
import EstimateCalculator from '../EstimateCalculator';
import 'bootstrap/dist/css/bootstrap.min.css';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'; // Import the default CSS for DatePicker

const DetailsStep = ({ 
  selectedService, 
  setBookingStartTime, 
  bookingStartTime, 
  bookingInstructions, 
  setBookingInstructions,
  bookingHours, 
  setBookingHours, 
  bookingDate, 
  setBookingDate 
}) => {
  const [estimatedHours, setEstimatedHours] = useState(0); // Estimated hours from EstimateCalculator
  const [showWarning, setShowWarning] = useState(false); // Warning state
  const [showEstimateCalculator, setShowEstimateCalculator] = useState(false); // Initially hide the EstimateCalculator

  const timeOptions = [
    '07:00', '07:30', '08:00', '08:30', '09:00', '09:30',
    '10:00', '10:30', '11:00', '11:30', '12:00', '12:30',
    '13:00', '13:30', '14:00'
  ];

  // Ensure booking hours cannot be less than the minimum set by selectedService
  useEffect(() => {
    if (bookingHours < selectedService.EstHours) {
      setBookingHours(selectedService.EstHours);
    }
  }, [bookingHours, selectedService.EstHours]);

  // Check if booking hours are less than estimated hours and show a warning
  useEffect(() => {
    if (bookingHours < estimatedHours) {
      setShowWarning(true);
    } else {
      setShowWarning(false);
    }
  }, [bookingHours, estimatedHours]);

  const incrementBookingHours = () => {
    setBookingHours((prev) => prev + 0.5);
  };

  const decrementBookingHours = () => {
    if (bookingHours > selectedService.EstHours) {
      setBookingHours((prev) => prev - 0.5);
    }
  };

  const toggleEstimateCalculator = () => {
    setShowEstimateCalculator((prev) => !prev);
  };

  // Get tomorrow's date in YYYY-MM-DD format
  const getTomorrowDate = () => {
    const today = new Date();
    today.setDate(today.getDate() + 1);
    return today;
  };

  // Get the date 14 days from tomorrow in YYYY-MM-DD format
  const getMaxDate = () => {
    const today = new Date();
    today.setDate(today.getDate() + 15); // 1 day for tomorrow + 14 days
    return today;
  };

  return (
    <div className="container mt-4">
      <p style={{ fontWeight: 'bold' }}>Need help with {selectedService?.Name}?</p>

      {/* Brief message about Estimate Calculator */}
      <div className="mb-3">
        <p>Need help estimating how long the job will take? Use our Estimate Calculator below!</p>
      </div>

      {/* Toggle button for Estimate Calculator */}
      <button 
        className="btn btn-primary mb-3" 
        onClick={toggleEstimateCalculator}
      >
        {showEstimateCalculator ? 'Hide' : 'Show'} Estimate Calculator
      </button>

      {/* Conditionally render the Estimate Calculator */}
      {showEstimateCalculator && (
        <div className="mb-4">
          <EstimateCalculator
            selectedService={selectedService}
            setEstimatedHours={setEstimatedHours}
            estimatedHours={estimatedHours}
          />
        </div>
      )}

      <div className="mb-4">
        <h4>Set Work Date</h4>
        <DatePicker
          selected={bookingDate ? new Date(bookingDate) : null}
          onChange={(date) => setBookingDate(date ? date.toISOString().split('T')[0] : '')}
          minDate={getTomorrowDate()}
          maxDate={getMaxDate()}
          className="form-control"
          dateFormat="yyyy-MM-dd"
        />
      </div>

      <div className="mb-4">
        <h4>Set Work Start Time</h4>
        <select
          className="form-select"
          value={bookingStartTime}
          onChange={(e) => setBookingStartTime(e.target.value)}
        >
          <option value="" disabled>Select a start time</option>
          {timeOptions.map((time) => (
            <option key={time} value={time}>
              {time}
            </option>
          ))}
        </select>
      </div>

      <div className="mb-4">
        <h4>Additional Instructions</h4>
        <textarea
          className="form-control"
          value={bookingInstructions}
          onChange={(e) => setBookingInstructions(e.target.value)}
          placeholder="Add any special instructions..."
        />
      </div>

      <div className="mb-4 d-flex align-items-center">
        <h4 className="me-3" style={{ fontWeight: 'bold' }}>Booking Hours</h4>
        <button 
          className="btn btn-secondary me-2" 
          onClick={decrementBookingHours}
        >
          -
        </button>
        <span className="me-2" style={{ fontWeight: 'bold' }}>{bookingHours}</span>
        <button 
          className="btn btn-secondary" 
          onClick={incrementBookingHours}
        >
          +
        </button>
      </div>

      {showWarning && (
        <div className="text-danger mb-3">
          Please ensure you are booking enough time to complete the job.
        </div>
      )}

      {/* Only show this if estimatedHours > selectedService.EstHours */}
      {estimatedHours > selectedService.EstHours && (
        <p>Estimated Work Hours: {estimatedHours}</p>
      )}

      <p style={{ fontWeight: 'bold', color: 'green' }}>Booking Hours: {bookingHours}</p>
      <p style={{ fontWeight: 'bold', color: 'green' }}>Cost: R{bookingHours * 50}</p>
    </div>
  );
};

export default DetailsStep;
