import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css'; // Ensure Bootstrap CSS is imported

// Sample bookings data
const bookings = [
  {
    id: 1,
    service: 'Indoor Cleaning',
    workerName: 'Alice Johnson',
    date: '2024-09-15',
    startTime: '09:00 AM',
    address: '123 Main St, Anytown, USA',
    status: 'Confirmed',
  },
  {
    id: 2,
    service: 'Outdoor Cleaning',
    workerName: 'Bob Smith',
    date: '2024-09-16',
    startTime: '01:00 PM',
    address: '456 Elm St, Othertown, USA',
    status: 'Pending',
  },
  // Add more bookings as needed
];

const handleCancel = (id) => {
  // Implement your cancel logic here
  console.log(`Cancel booking with id: ${id}`);
};

const Bookings = () => {
  return (
    <div className="container mt-4">
      <h2 className="mb-4">Bookings</h2>
      <div className="table-responsive">
        <table className="table table-bordered table-striped">
          <thead>
            <tr>
              <th>Service</th>
              <th>Worker</th>
              <th>Date</th>
              <th>Start Time</th>
              <th>Address</th>
              <th>Status</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {bookings.map((booking) => (
              <tr key={booking.id}>
                <td>{booking.service}</td>
                <td>{booking.workerName}</td>
                <td>{booking.date}</td>
                <td>{booking.startTime}</td>
                <td>{booking.address}</td>
                <td>{booking.status}</td>
                <td>
                  <button 
                    className="btn btn-danger btn-sm"
                    onClick={() => handleCancel(booking.id)}
                  >
                    Cancel
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Bookings;
