// src/data/services.js

export const services = [
    {
      Id: 1,
      Name: "Indoor Cleaning",
      Description: "General indoor cleaning, tidying up, mopping, dishes. Extras include: Laundry, Windows, Fridge, Cabinets.",
      EstHours: 3.5,
      Extras: [
        { Id: 1, Name: "Laundry", Description: "Doing laundry, ironing and folding", EstHours: 1.5 },
        { Id: 2, Name: "Windows", Description: "Cleaning interior windows", EstHours: 1 },
        { Id: 3, Name: "Fridge", Description: "Cleaning inside the fridge", EstHours: 1 },
        { Id: 4, Name: "Cabinets", Description: "Cleaning inside cabinets", EstHours: 1 },
      ],
    },
    {
      Id: 3,
      Name: "Outdoor Cleaning",
      EstHours: 3.5,
      Description: "General outdoor cleaning, patios, driveways, deweeding, mowing grass. Extras include: Pool, Roof, Exterior Windows.",
      Extras: [
        { Id: 1, Name: "Pool", Description: "Cleaning the pool", EstHours: 1 },
        { Id: 2, Name: "Outside Windows", Description: "Cleaning exterior windows", EstHours: 1 },
        { Id: 3, Name: "GardernMaintanance", Description: "Clean and Maintain Garder", EstHours: 2.5 },
      ],
    },
  ];
  