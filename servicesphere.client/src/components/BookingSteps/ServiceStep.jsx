import React, { useState, useEffect } from 'react';
import { Card, Row, Col } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

// Import images
import indoorCleaning from '../../assets/pictures/indoorcleaning.png';
import outdoorCleaning from '../../assets/pictures/outdoorcleaning.jpg';

const ServiceStep = ({ selectedService, setSelectedService }) => {
  const [services, setServices] = useState([]); // State for services
  const [error, setError] = useState(''); // State for error handling

  useEffect(() => {
    const fetchServices = async () => {
      try {
        const response = await fetch('http://localhost:5062/api/Service', {
          method: 'GET',
          headers: {
            'Accept': '*/*',
          },
        });

        if (!response.ok) {
          throw new Error('Failed to fetch services');
        }

        const data = await response.json();
        setServices(data); // Set the fetched data to the services state
      } catch (error) {
        setError(error.message);
      }
    };

    fetchServices(); // Call the function to fetch services
  }, []); // Empty dependency array means this effect runs once on mount

  const handleServiceSelect = (service) => {
    setSelectedService(service);
  };

  // Function to map service names to images
  const getServiceImage = (serviceName) => {
    if (serviceName === 'Indoor Cleaning') {
      return indoorCleaning;
    } else if (serviceName === 'Outdoor Cleaning') {
      return outdoorCleaning;
    }
    return null; // Default if no matching image
  };

  return (
    <div className="container mt-5">
      <h2 className="mb-4 text-center" style={{ color: '#007bff', fontWeight: 'bold' }}>Select a Service</h2>
      {error && <div className="alert alert-danger text-center">{error}</div>} {/* Error message */}
      <Row className="d-flex justify-content-center">
        {services.map((service) => (
          <Col md={6} lg={4} key={service.id} className="mb-4 d-flex justify-content-center">
            <Card
              border={selectedService?.id === service.id ? 'primary' : 'light'}
              className={`cursor-pointer shadow-sm ${selectedService?.id === service.id ? 'shadow-lg border-primary' : ''}`}
              onClick={() => handleServiceSelect(service)}
              style={{
                borderRadius: '15px',
                transition: 'transform 0.3s ease, box-shadow 0.3s ease',
                transform: selectedService?.id === service.id ? 'scale(1.05)' : 'scale(1)',
                backgroundColor: selectedService?.id === service.id ? '#e7f0ff' : '#fff',
                width: '100%',
                maxWidth: '300px',
                minHeight: '350px',
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
              }}
            >
              <Card.Body className="text-center">
                <Card.Title style={{ color: '#007bff', fontSize: '1.5rem', fontWeight: '600' }}>
                  {service.name}
                </Card.Title>
                {/* Image Section */}
                <div className="mb-3">
                  <img
                    src={getServiceImage(service.name)}
                    alt={`${service.name}`}
                    style={{
                      width: '100%',
                      height: '150px',
                      objectFit: 'cover',
                      borderRadius: '10px',
                    }}
                  />
                </div>
                <Card.Text className="mt-2" style={{ color: '#6c757d', fontSize: '1rem' }}>
                  {service.description}
                </Card.Text>
              </Card.Body>
            </Card>
          </Col>
        ))}
      </Row>
    </div>
  );
};

export default ServiceStep;
