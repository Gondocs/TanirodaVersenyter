import React from "react";
import logo from "../Images/taniroda_weboldal_logo.png";
import { Link } from "react-router-dom";
import { useAuth } from "./Auth/Auth";
import { useNavigate } from "react-router-dom";

const Navbar = () => {
  const { token, setToken } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    setToken();
    navigate("/", { replace: true });
  };

  return (
    <nav className="bg-gray-100 p-4 border-b-black border-b-2">
      <div className="container mx-auto flex justify-between items-center">
        {/* Logo */}
        <div className="text-white font-bold text-xl">
          <Link to="/">
            <img
              src={logo}
              alt="TanirodaVersenyTér Logo"
              style={{ maxHeight: "65px" }}
            />
          </Link>
          {/*<a href="#">MyLogo</a>*/}
        </div>

        {/* Links */}
        <div>
          {token ? (
            <button
              onClick={handleLogout}
              className="text-white bg-gray-700 hover:bg-gray-800 font-semibold py-2 px-4 rounded"
            >
              Kijelentkezés
            </button>
          ) : (
            // Render login and registration links if not logged in
            <>
              <Link
                to="/belepes"
                className="text-gray-700 hover:text-gray-900 mr-4"
              >
                <button className="text-white bg-gray-700 hover:bg-gray-800 font-semibold py-2 px-4 rounded mr-2">
                  Belépés
                </button>
              </Link>
              <Link
                to="/regisztracio"
                className="text-gray-700 hover:text-gray-900"
              >
                <button className="text-white bg-gray-700 hover:bg-gray-800 font-semibold py-2 px-4 rounded">
                  Regisztráció
                </button>
              </Link>
            </>
          )}
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
