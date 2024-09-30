import React, { useState, useEffect } from 'react';
import ServiceStep from '../components/BookingSteps/ServiceStep';
import AddressStep from '../components/BookingSteps/AddressStep';
import DetailsStep from '../components/BookingSteps/DetailsStep';
import WorkerStep from '../components/BookingSteps/WorkerStep';
import ProgressTracker from '../components/ProgressTracker';
import ConfirmStep from '../components/BookingSteps/ConfirmStep';

const steps = ['Service', 'Address', 'Details', 'Worker', 'Confirm'];

const BookingLayout = () => {
  const [currentStep, setCurrentStep] = useState(0);
  const [selectedService, setSelectedService] = useState('');
  const [address, setAddress] = useState('');
  const [bookingInstructions, setBookingInstructions] = useState('');
  const [bookingStartTime, setBookingStartTime] = useState('');
  const [bookingDate, setBookingDate] = useState('');
  const [bookingHours, setBookingHours] = useState(selectedService?.EstHours || 0);
  const [selectedWorker, setSelectedWorker] = useState('');
  const [area, setArea] = useState('');
  const [city, setCity] = useState('');

  useEffect(() => {
    console.log('Selected Service:', selectedService);
  }, [selectedService]);

  useEffect(() => {
    console.log('Address:', address);
  }, [address]);

  const nextStep = () => {
    if (currentStep < steps.length - 1) {
      setCurrentStep(currentStep + 1);
    }
  };

  const prevStep = () => {
    if (currentStep > 0) {
      setCurrentStep(currentStep - 1);
    }
  };

  const isNextButtonDisabled = () => {
    if (currentStep === 0) {
      return !selectedService;
    } else if (currentStep === 1) {
      return !address;
    } else if (currentStep === 2) {
      return !bookingDate || !bookingStartTime;
    } else if (currentStep === 3) {
      return !selectedWorker;
    } else if (currentStep === 4) {
      return !selectedService || !address || !selectedWorker;
    }
    return false;
  };

  const renderStepComponent = () => {
    switch (currentStep) {
      case 0:
        return <ServiceStep 
          selectedService={selectedService} 
          setSelectedService={setSelectedService} />;

      case 1:
        return <AddressStep 
          address={address} 
          setAddress={setAddress}
          city = {city}
          setArea = {setArea}
          area = {area} 
          setCity={setCity}/>;
      case 2:
        return <DetailsStep 
          selectedService={selectedService} 
          bookingStartTime={bookingStartTime} 
          setBookingStartTime={setBookingStartTime} 
          bookingInstructions={bookingInstructions} 
          setBookingInstructions={setBookingInstructions}
          bookingHours={bookingHours} 
          setBookingHours={setBookingHours} 
          bookingDate={bookingDate} 
          setBookingDate={setBookingDate} />;
      case 3:
        return <WorkerStep 
          selectedService={selectedService}
          address={address}
          bookingDate={bookingDate}
          bookingHours={bookingHours}  
          setSelectedWorker={setSelectedWorker} />;
      case 4:
        return <ConfirmStep
          selectedService={selectedService} 
          bookingHours={bookingHours} 
          address={address}
          selectedWorker={selectedWorker}
          bookingDate={bookingDate} 
          bookingStartTime={bookingStartTime} />;
      default:
        return <ServiceStep 
          selectedService={selectedService} 
          setSelectedService={setSelectedService} />;
    }
  };

  return (
    <div className="container mt-4 mb-4">
      <ProgressTracker currentStep={currentStep} steps={steps} />
      {renderStepComponent()}
      <div className="d-flex justify-content-between mt-4">
        <button 
          onClick={prevStep} 
          disabled={currentStep === 0} 
          className="btn btn-secondary"
        >
          Previous
        </button>
        <button 
          onClick={nextStep} 
          disabled={isNextButtonDisabled()} 
          className="btn btn-primary"
        >
          Next
        </button>
      </div>
    </div>
  );
};

export default BookingLayout;
