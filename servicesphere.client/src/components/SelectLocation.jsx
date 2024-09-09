// src/components/SelectLocation.jsx
import React, { useState, useCallback, useEffect } from 'react';
import { GoogleMap, useLoadScript, Marker, Autocomplete } from '@react-google-maps/api';
import '../component-specific-css/SelectLocation.css'; // Adjust the path as needed

// Set up constants
const libraries = ['places'];
const mapContainerStyle = {
  height: '400px',
  width: '100%',
};
// Default center position for Johannesburg, South Africa
const defaultCenter = {
  lat: -26.2041, // Latitude for Johannesburg
  lng: 28.0473, // Longitude for Johannesburg
};

const SelectLocation = ({ address, setlocation }) => {
  const { isLoaded, loadError } = useLoadScript({
    googleMapsApiKey: 'AIzaSyBGDE4pWS9YB1tY_rZascs7B3OIdZYYsGM', // Replace with your API key
    libraries,
  });

  const [address, setAddress] = useState('');
  const [markerPosition, setMarkerPosition] = useState(defaultCenter);

  const onPlaceChanged = useCallback((autocomplete) => {
    const place = autocomplete.getPlace();
    if (place.geometry) {
      // Update the marker position and address
      const newLocation = {
        lat: place.geometry.location.lat(),
        lng: place.geometry.location.lng(),
      };
      setMarkerPosition(newLocation);
      setAddress(place.formatted_address);
      if (onLocationSelect) {
        onLocationSelect(newLocation); // Notify parent about the selected location
      }
    } else {
      console.error('Place details are not available.');
    }
  }, [onLocationSelect]);

  useEffect(() => {
    if (location) {
      setMarkerPosition(location);
      // Use a geocoder to set the address based on the location
      const geocoder = new window.google.maps.Geocoder();
      geocoder.geocode({ location }, (results, status) => {
        if (status === 'OK' && results[0]) {
          setAddress(results[0].formatted_address);
        }
      });
    }
  }, [location]);

  if (loadError) return <div>Error loading maps</div>;
  if (!isLoaded) return <div>Loading...</div>;

  return (
    <div className="map-container">
      <h2>Select Location</h2>
      <div className="map-wrapper">
        <GoogleMap
          mapContainerStyle={mapContainerStyle}
          zoom={15}
          center={markerPosition}
          options={{
            streetViewControl: false,
            mapTypeControl: false,
          }}
        >
          <Marker position={markerPosition} />
        </GoogleMap>
        <div className="autocomplete-container">
          <Autocomplete
            onLoad={(autocomplete) => {
              if (autocomplete) {
                autocomplete.addListener('place_changed', () => onPlaceChanged(autocomplete));
              }
            }}
          >
            <input
              type="text"
              placeholder="Enter your address"
              className="form-control"
              value={address}
              onChange={(e) => setAddress(e.target.value)}
            />
          </Autocomplete>
        </div>
      </div>
    </div>
  );
};

export default SelectLocation;


//AIzaSyBGDE4pWS9YB1tY_rZascs7B3OIdZYYsGM