import React from "react";
import logo from "./logo.svg";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import "./App.css";
// import { AuthPage } from "./components/pages/AuthPage/AuthPage";
import { Logo } from "./components/UI/Logo";
import { Button } from "./components/UI/Button";
// import { TextInputDisplay } from "./components/UI/InputText";
import { UserTable } from "./components/UI/UserTable";
import { NavBarGuest } from "./components/UI/NavBarGuest";
import { Login } from "./components/pages/LoginPage";
import { Registration } from "./components/pages/RegistrationPage";
import { NavBarAdmin } from "./components/UI/NavBarAdmin";
import { NavBarReferee } from "./components/UI/NavBarReferee";
import { AdminClubPage } from "./components/pages/AdminClubPage";
import { AdminUserPage } from "./components/pages/AdminUserPage";
import { RefereeLeaguePage } from "./components/pages/RefereeLeaguePage";
import { RefereeMatchPage } from "./components/pages/RefereeMatchPage";
import { GuestLeaguePage } from "./components/pages/GuestLeaguePage";
// import { ClubPage } from "./components/pages/ClubPage/ClubPage";
// import { ClubsPage } from "./components/pages/ClubsPage/ClubsPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />
        <Route path="/registrate" element={<Registration />} />
        <Route path="/admin/users" element={<AdminUserPage />} />
        <Route path="/admin/clubs" element={<AdminClubPage />} />
        <Route path="/referee/:id/leagues" element={<RefereeLeaguePage />} />
        <Route path="/leagues/:id/matches" element={<RefereeMatchPage />} />
        <Route path="/guest/leagues" element={<GuestLeaguePage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
