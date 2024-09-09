import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css'; // Ensure Bootstrap CSS is imported

// Sample jobs data
const jobs = [
  {
    id: 1,
    client: 'John Doe',
    date: '2024-09-10',
    startTime: '10:00 AM',
    address: '789 Maple St, Sampletown, USA',
    status: 'Scheduled',
  },
  {
    id: 2,
    client: 'Jane Smith',
    date: '2024-09-11',
    startTime: '02:00 PM',
    address: '321 Oak St, Exampletown, USA',
    status: 'Completed',
  },
  {
    id: 3,
    client: 'Robert Brown',
    date: '2024-09-12',
    startTime: '09:30 AM',
    address: '654 Pine St, Testville, USA',
    status: 'Cancelled',
  },
  // Add more jobs as needed
];

const Jobs = () => {
  return (
    <div className="container mt-4">
      <h2 className="mb-4">Jobs</h2>
      <div className="table-responsive">
        <table className="table table-bordered table-striped">
          <thead>
            <tr>
              <th>Client</th>
              <th>Date</th>
              <th>Start Time</th>
              <th>Address</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            {jobs.map((job) => (
              <tr key={job.id}>
                <td>{job.client}</td>
                <td>{job.date}</td>
                <td>{job.startTime}</td>
                <td>{job.address}</td>
                <td>{job.status}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Jobs;
