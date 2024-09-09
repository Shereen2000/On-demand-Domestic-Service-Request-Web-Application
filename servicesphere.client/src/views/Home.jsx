import React from 'react';
import { Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

const Home = () => {
  return (
    <div className="container text-center my-5">
      <h1 className="display-4 mb-4">Welcome to <span className="text-success">ServiceSphere</span></h1>
      <p className="lead mb-5">
        We provide the best helpers to do the work for you. Sit back and relax while we take care of everything!
      </p>

      <div className="d-flex justify-content-center mb-4">
        <Link to="/book" className="btn btn-success btn-lg mx-2 shadow-lg">
          Make a Booking
        </Link>
      </div>

      <div className="mt-4">
        <p className="mb-3">Want to join us?</p>
        <Link to="/become-provider" className="text-decoration-none text-success fw-bold">
          Become a helper
        </Link>
      </div>
    </div>
  );
};

export default Home;
