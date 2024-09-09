import React from 'react';
import { services } from '../../data/services'; // Adjust the path as needed
import { Card, Row, Col } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

// Import images
import indoorCleaning from '../../assets/pictures/indoorcleaning.png'
import outdoorCleaning from '../../assets/pictures/outdoorcleaning.jpg';

const ServiceStep = ({ selectedService, setSelectedService }) => {
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
      <Row className="d-flex justify-content-center">
        {services.map((service) => (
          <Col md={6} lg={4} key={service.Id} className="mb-4 d-flex justify-content-center">
            <Card
              border={selectedService?.Id === service.Id ? 'primary' : 'light'}
              className={`cursor-pointer shadow-sm ${selectedService?.Id === service.Id ? 'shadow-lg border-primary' : ''}`}
              onClick={() => handleServiceSelect(service)}
              style={{
                borderRadius: '15px',
                transition: 'transform 0.3s ease, box-shadow 0.3s ease',
                transform: selectedService?.Id === service.Id ? 'scale(1.05)' : 'scale(1)',
                backgroundColor: selectedService?.Id === service.Id ? '#e7f0ff' : '#fff',
                width: '100%',
                maxWidth: '300px',
                minHeight: '350px', // Adjust height for image space
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'center',
              }}
            >
              <Card.Body className="text-center">
                <Card.Title style={{ color: '#007bff', fontSize: '1.5rem', fontWeight: '600' }}>
                  {service.Name}
                </Card.Title>
                {/* Image Section */}
                <div className="mb-3">
                  <img
                    src={getServiceImage(service.Name)}
                    alt={`${service.Name}`}
                    style={{
                      width: '100%',
                      height: '150px',
                      objectFit: 'cover',
                      borderRadius: '10px',
                    }}
                  />
                </div>
                <Card.Text className="mt-2" style={{ color: '#6c757d', fontSize: '1rem' }}>
                  {service.Description}
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
