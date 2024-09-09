import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

const ProgressTracker = ({ currentStep, steps }) => {
  return (
    <div className="container mt-4">
      <ul className="d-flex list-unstyled">
        {steps.map((step, index) => (
          <li
            key={step}
            className={`d-inline mx-2 ${currentStep === index ? 'text-primary fw-bold' : 'text-muted'}`}
          >
            <span className={`d-inline ${currentStep === index ? 'border-bottom border-primary' : ''}`}>
              {step}
            </span>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ProgressTracker;
