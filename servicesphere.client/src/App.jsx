import { Routes, Route } from 'react-router-dom';
import MainLayout from './layouts/MainLayout';
import Home from './views/Home';
import Login from './views/Login';
import Register from './views/Register';
import BecomeProvider from './views/BecomeProvider';
import Bookings from './views/Bookings';
import Jobs from './views/Jobs';
import Admin from './views/Admin';
import Account from './views/Account';
import BookingLayout from './layouts/BookingLayout';
import RequireAuth from './authentication/RequireAuth';

const AppRoutes = () => {
  return (
    <Routes>
      {/* Main Layout for most routes */}
      <Route path="/" element={<MainLayout />}>
        
        {/* Public Routes */}
        <Route index element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        
        {/* Protected Routes (only accessible if authenticated) */}
        <Route element={<RequireAuth />}>
          <Route path="/become-provider" element={<BecomeProvider />} />
          <Route path="/bookings" element={<Bookings />} />
          <Route path="/jobs" element={<Jobs />} />
          <Route path="/admin" element={<Admin />} />
          <Route path="/account" element={<Account />} />
          <Route path="/book" element={<BookingLayout />} />
        </Route>
        
      </Route>
    </Routes>
  );
};

export default AppRoutes;
