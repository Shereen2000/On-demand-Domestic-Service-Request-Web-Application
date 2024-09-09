import React, { createContext, useState } from 'react';

const AuthContext = createContext({});

export const AuthProvider = ({ children }) => {
  const [auth, setAuth] = useState({});
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const login = (userAuth) => {
    setAuth(userAuth);
    setIsLoggedIn(true);
  };

  const logout = () => {
    setAuth({});
    setIsLoggedIn(false);
  };

  return (
    <AuthContext.Provider value={{ auth, setAuth, isLoggedIn, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
