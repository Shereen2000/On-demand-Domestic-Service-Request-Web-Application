import React, { useState } from 'react';
import { workers } from '../../data/workers'; // Adjust the path as needed

const WorkerStep = ({ setSelectedWorker }) => {
  const [showReviews, setShowReviews] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [selectedWorkerId, setSelectedWorkerId] = useState('');
  const reviewsPerPage = 3;

  const handleHire = (workerId) => {
    const selectedWorker = workers.find((worker) => worker.id === workerId);
    setSelectedWorkerId(workerId);
    setShowReviews(false); // Hide reviews when hiring a worker
    setSelectedWorker(selectedWorker);
  };

  const handleToggleReviews = (workerId) => {
    if (selectedWorkerId === workerId) {
      setShowReviews(!showReviews);
    } else {
      setSelectedWorkerId(workerId);
      setShowReviews(true);
      setCurrentPage(1); // Reset to first page when showing new worker's reviews
    }
  };

  const handlePageChange = (newPage) => {
    setCurrentPage(newPage);
  };

  const getPagedReviews = (reviews, page, perPage) => {
    const start = (page - 1) * perPage;
    return reviews.slice(start, start + perPage);
  };

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Available Workers</h2>
      {workers.map((worker) => (
        <div 
          key={worker.id} 
          className={`border rounded p-3 mb-3 ${selectedWorkerId === worker.id ? 'border-success' : 'border-secondary'}`}
        >
          <img 
            src={worker.profilePictureUrl} 
            alt={`${worker.name}'s profile`} 
            className="img-fluid rounded-circle mb-2"
            style={{ width: '100px', height: '100px' }}
          />
          <h3>{worker.name}</h3>
          <p>Rating: {worker.rating} / 5</p>
          <p>Jobs Completed: {worker.jobsCompleted}</p>
          <p>About Me: {worker.aboutMe}</p>
          <p>Available Days: {worker.availability.join(', ')}</p>
          <button 
            onClick={() => handleHire(worker.id)}
            className={`btn ${selectedWorkerId === worker.id ? 'btn-success' : 'btn-primary'} me-2`}
          >
            {selectedWorkerId === worker.id ? 'Selected' : 'Select'}
          </button>
          <button 
            onClick={() => handleToggleReviews(worker.id)}
            className="btn btn-secondary"
          >
            {selectedWorkerId === worker.id && showReviews ? 'Hide Reviews' : 'Show Reviews'}
          </button>
          {selectedWorkerId === worker.id && showReviews && (
            <div className="mt-3">
              <h4>Reviews:</h4>
              {worker.reviews.length > 0 ? (
                <>
                  {getPagedReviews(worker.reviews, currentPage, reviewsPerPage).map((review) => (
                    <div key={review.id} className="border-top pt-3 mt-3">
                      <p><strong>{review.reviewer}</strong> (Rating: {review.rating}/5)</p>
                      <p>{review.text}</p>
                    </div>
                  ))}
                  <div className="mt-3">
                    <button
                      onClick={() => handlePageChange(currentPage - 1)}
                      className="btn btn-outline-secondary"
                      disabled={currentPage === 1}
                    >
                      Previous
                    </button>
                    <span className="mx-3">Page {currentPage}</span>
                    <button
                      onClick={() => handlePageChange(currentPage + 1)}
                      className="btn btn-outline-secondary"
                      disabled={currentPage * reviewsPerPage >= worker.reviews.length}
                    >
                      Next
                    </button>
                  </div>
                </>
              ) : (
                <p>No reviews yet.</p>
              )}
            </div>
          )}
        </div>
      ))}
    </div>
  );
};

export default WorkerStep;
