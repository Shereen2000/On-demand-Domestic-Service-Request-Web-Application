import React, { useState, useCallback, useEffect } from 'react';
import { GoogleMap, useLoadScript, Marker, Autocomplete } from '@react-google-maps/api';
import 'bootstrap/dist/css/bootstrap.min.css';

// Define your Google Maps API key
const API_KEY = process.env.REACT_APP_GOOGLE_MAPS_API_KEY;

const AddressStep = ({ setAddress, address }) => {
  const [map, setMap] = useState(null);
  const [marker, setMarker] = useState(null);
  const [autocomplete, setAutocomplete] = useState(null);
  const [inputValue, setInputValue] = useState(address);

  const { isLoaded } = useLoadScript({
    googleMapsApiKey: API_KEY,
    libraries: ['places'],
  });

  const onMapLoad = useCallback((mapInstance) => {
    setMap(mapInstance);
  }, []);

  const handlePlaceSelect = () => {
    const place = autocomplete.getPlace();
    if (place && place.geometry) {
      const newAddress = place.formatted_address;
      const newLocation = place.geometry.location;

      setAddress(newAddress); // Update the address in the parent component
      setMarker({ lat: newLocation.lat(), lng: newLocation.lng() });

      map.panTo(newLocation); // Center the map on the selected address
      setInputValue(newAddress); // Update the input field with the selected address
    }
  };

  const handleInputChange = (e) => {
    setInputValue(e.target.value); // Update the input field value
    setAddress(e.target.value); // Update the address in the parent component
  };

  useEffect(() => {
    setInputValue(address); // Set the input field value when address changes
  }, [address]);

  if (!isLoaded) return <div className="text-center">Loading...</div>;

  return (
    <div className="container mt-4">
      <div className="row">
        <div className="col-12 col-md-6 mb-3">
          <Autocomplete
            onLoad={setAutocomplete}
            onPlaceChanged={handlePlaceSelect}
            types={['address']}
          >
            <input
              type="text"
              placeholder="Enter your address"
              className="form-control"
              value={inputValue}
              onChange={handleInputChange}
            />
          </Autocomplete>
        </div>
        <div className="col-12 col-md-6">
          <div style={{ position: 'relative', height: '0', paddingBottom: '56.25%' }}>
            <GoogleMap
              id="map"
              mapContainerStyle={{ position: 'absolute', top: '0', left: '0', width: '100%', height: '100%' }}
              zoom={15}
              center={marker ? marker : { lat: -34.397, lng: 150.644 }}
              onLoad={onMapLoad}
            >
              {marker && <Marker position={marker} />}
            </GoogleMap>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddressStep;
