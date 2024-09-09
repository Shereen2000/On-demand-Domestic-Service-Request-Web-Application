// src/data/workers.js

export const workers = [
    {
      id: 1,
      name: 'Alice Johnson',
      rating: 4.8,
      jobsCompleted: 150,
      aboutMe: 'Experienced professional with a passion for quality work.',
      availability: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'],
      profilePictureUrl: 'https://images.ctfassets.net/pdf29us7flmy/783XmiskxZ3dnFh1SdIOKt/56f5015d13fa18fca1fb9d232a85b1af/resized.jpg?w=414&q=100&fm=avif',
      reviews: [
        { id: 1, reviewer: 'John Doe', rating: 5, text: 'Alice did a fantastic job! Highly recommend her services.' },
        { id: 2, reviewer: 'Jane Smith', rating: 4, text: 'Good work, but there was a slight delay in the schedule.' },
        { id: 3, reviewer: 'Michael Brown', rating: 5, text: 'Alice was very thorough and professional.' },
        { id: 4, reviewer: 'Emily White', rating: 4, text: 'Great job overall, but could improve in communication.' },
        { id: 5, reviewer: 'Chris Green', rating: 3, text: 'Satisfactory work, but there is room for improvement.' }
      ]
    },
    {
      id: 2,
      name: 'Bob Smith',
      rating: 4.5,
      jobsCompleted: 200,
      aboutMe: 'Dedicated and reliable with extensive experience in the field.',
      availability: ['Monday', 'Tuesday', 'Wednesday', 'Saturday', 'Sunday'],
      profilePictureUrl: 'https://images.ctfassets.net/pdf29us7flmy/783XmiskxZ3dnFh1SdIOKt/56f5015d13fa18fca1fb9d232a85b1af/resized.jpg?w=414&q=100&fm=avif',
      reviews: [
        { id: 1, reviewer: 'Emily White', rating: 4, text: 'Bob was very professional and completed the job on time.' },
        { id: 2, reviewer: 'Michael Brown', rating: 5, text: 'Excellent service and very knowledgeable.' },
        { id: 3, reviewer: 'Sarah Wilson', rating: 4, text: 'Bob did a good job, but there were a few minor issues.' },
        { id: 4, reviewer: 'James Davis', rating: 5, text: 'Bob exceeded expectations, very satisfied.' },
        { id: 5, reviewer: 'Linda Clark', rating: 3, text: 'The service was okay, but there is room for improvement.' }
      ]
    },
    // Add more workers as needed
  ];
  