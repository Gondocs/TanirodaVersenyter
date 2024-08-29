import React from "react";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { showToast } from "./Toasts/toast";
import { post } from "./api/api";
import { useAuth } from "./Auth/Auth";
import { jwtDecode } from "jwt-decode";

const LoginPage = () => {
  const { setToken } = useAuth();
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    post
      .LoginData(formData)
      .then(({ token }) => {
        setToken(token);
        const decoded = jwtDecode(token);

        navigate("/", { replace: true });
        showToast("Sikeres Bejelentkezés!", "success");
        console.log(token);
        console.log(decoded);
      })
      .catch((error) => {
        showToast("Hiba történt a belépés közben: " + error.message, "error");
        console.log(error);
      });
  };

  return (
    <div className="h-screen flex items-center justify-center bg-gray-100">
      <div className="bg-white p-12 rounded-xl shadow-2xl w-full max-w-lg">
        <h2 className="text-3xl font-bold mb-8 text-center">Belépés</h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-6">
            <label className="block text-gray-700 text-lg">Email</label>
            <input
              type="email"
              className="w-full px-4 py-3 text-lg border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Email"
              autoComplete="email"
              required
              onChange={handleChange}
              value={formData.email}
              name="email"
              id="email"
            />
          </div>
          <div className="mb-8">
            <label className="block text-gray-700 text-lg">Jelszó</label>
            <input
              type="password"
              className="w-full px-4 py-3 text-lg border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Jelszó"
              autoComplete="current-password"
              required
              onChange={handleChange}
              value={formData.password}
              name="password"
              id="password"
            />
          </div>
          <button className="w-full bg-blue-600 text-white py-3 rounded-lg font-semibold text-lg hover:bg-blue-700">
            Belépés
          </button>
        </form>
        <p className="text-center mt-6 text-lg">
          Nincs még fiókod?{" "}
          <a href="/regisztracio" className="text-blue-600 hover:underline">
            Regisztráció
          </a>
        </p>
      </div>
    </div>
  );
};

export default LoginPage;
