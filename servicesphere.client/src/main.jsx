import React from 'react'
import ReactDom from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { AuthProvider } from './context/AuthProvider.jsx' 

ReactDom.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
  <BrowserRouter>
  <AuthProvider>
      <Routes>
        <Route path = "/*" element= {<App/> }> </Route>
      </Routes>
  </AuthProvider>
  </BrowserRouter>
</React.StrictMode>
)
