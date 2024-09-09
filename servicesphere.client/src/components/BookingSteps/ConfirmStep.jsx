import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate } from 'react-router-dom'; // Import useNavigate from react-router-dom

const ServiceFees = 25.00;
const Insurance = 15.00;
const HourlyCharges = 50.00;

const ConfirmStep = ({
  selectedService,
  bookingHours,
  address,
  selectedWorker,
  bookingStartTime,
  bookingDate
}) => {
  const [requireInsurance, setRequireInsurance] = useState(true);
  const navigate = useNavigate(); // Initialize useNavigate

  // Calculate total cost including insurance if required
  const totalCosts = bookingHours * HourlyCharges + ServiceFees + (requireInsurance ? Insurance : 0);

  const handleConfirmBooking = () => {
    // Show confirmation message
    alert("Service booked!");

    // Redirect to the home page
    navigate('/');
  };

  return (
    <div className="container mt-4">
      <div className="card p-4 border-primary mb-4">
        <p className="mb-3">
          You are booking <strong>{selectedService?.Name}</strong> services from <strong>{selectedWorker?.name}</strong>. 
          The service is scheduled for <strong>{bookingDate}</strong>, starting at <strong>{bookingStartTime}</strong>, 
          at <strong>{address}</strong>.
        </p>

        <h4 className="mb-3">Costs Breakdown</h4>
        <p>Booking Costs: <strong>R{bookingHours * HourlyCharges}</strong></p>
        <p>Service Fees: <strong>R{ServiceFees}</strong></p>

        {/* Toggle insurance */}
        <div className="form-check mb-3">
          <input
            type="checkbox"
            className="form-check-input"
            id="insuranceCheck"
            checked={requireInsurance}
            onChange={() => setRequireInsurance(!requireInsurance)}
          />
          <label className="form-check-label" htmlFor="insuranceCheck">
            Require Insurance
          </label>
        </div>

        {requireInsurance && <p>Insurance Costs: <strong>R{Insurance}</strong></p>}

        <h3 className="mb-4">Total Costs: <strong className="text-success">R{totalCosts}</strong></h3>

        {/* Confirm booking button */}
        <button className="btn btn-primary" onClick={handleConfirmBooking}>
          Confirm Booking
        </button>

        {/* Explanation for not integrating a payment gateway */}
        {/* <p className="mt-4 text-muted">
          Note: I have not integrated a payment gateway because don't have expertise with payment integrations yet. This project is part of my 
          portfolio to demonstrate my development potential to recruiters and to gain an 
          internship where I can learn more.
        </p> */}
      </div>
    </div>
  );
};

export default ConfirmStep;
