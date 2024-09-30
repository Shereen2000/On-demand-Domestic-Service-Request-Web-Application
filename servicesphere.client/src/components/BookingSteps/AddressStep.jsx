import React, { useState, useCallback, useEffect } from 'react';
import { Autocomplete } from '@react-google-maps/api';
import 'bootstrap/dist/css/bootstrap.min.css';

const API_URL = "http://localhost:5062/api/City";

const AddressStep = ({ setAddress, address, area, setArea, city, setCity }) => {
  const [autocomplete, setAutocomplete] = useState(null);
  const [inputValue, setInputValue] = useState(address);
  
  const [cities, setCities] = useState([]);
  const [areas, setAreas] = useState([]);
  
  const fetchCities = async () => {
    try {
      const response = await fetch(API_URL);
      const data = await response.json();
      setCities(data);
    } catch (error) {
      console.error("Error fetching cities:", error);
    }
  };

  const extractAreasFromCity = (selectedCity) => {
    const allAreas = [];
    selectedCity.areaGroups.forEach(group => {
      allAreas.push(...group.areas);
    });
    setAreas(allAreas);
  };

  useEffect(() => {
    fetchCities();
  }, []);

  useEffect(() => {
    if (city) {
      extractAreasFromCity(city); 
    } else {
      setAreas([]);
    }
  }, [city]);

  useEffect(() => {
    setInputValue(address);
  }, [address]);

  const handlePlaceSelect = () => {
    const place = autocomplete.getPlace();
    if (place && place.geometry) {
      const newAddress = place.formatted_address;
      setAddress(newAddress);
      setInputValue(newAddress);
    }
  };

  const handleInputChange = (e) => {
    setInputValue(e.target.value);
    setAddress(e.target.value);
  };

  return (
    <div className="container mt-4">
      <div className="">
        <div className="col-12 col-md-6 mb-3">
          <select
            className="form-control"
            onChange={(e) => {
              const selectedCity = cities.find(c => c.id === parseInt(e.target.value));
              setCity(selectedCity);
            }}
          >
            <option value="">Select a city</option>
            {cities.map(city => (
              <option key={city.id} value={city.id}>{city.name}</option>
            ))}
          </select>
        </div>
        <div className="col-12 col-md-6 mb-3">
          <select
            className="form-control"
            onChange={(e) => {
              const selectedArea = areas.find(a => a.id === parseInt(e.target.value));
              setArea(selectedArea);
            }}
          >
            <option value="">Select an area</option>
            {areas.map(area => (
              <option key={area.id} value={area.id}>{area.name}</option>
            ))}
          </select>
        </div>
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
      </div>
    </div>
  );
};

export default AddressStep;
