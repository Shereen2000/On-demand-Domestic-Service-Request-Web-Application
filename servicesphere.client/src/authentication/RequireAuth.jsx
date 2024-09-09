import React from 'react';
import { useLocation, Navigate, Outlet } from 'react-router-dom';
import useAuth from '../hooks/useAuth';

const RequireAuth = () => {
  const { isLoggedIn } = useAuth();
  const location = useLocation();

  // If not logged in, redirect to login page
  if (!isLoggedIn) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  // If logged in, render child routes
  return <Outlet />;
};

export default RequireAuth;
