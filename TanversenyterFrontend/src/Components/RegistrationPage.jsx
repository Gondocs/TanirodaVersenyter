import React from "react";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { showToast } from "./Toasts/toast";
import { validatePassword } from "./Validation/PasswordValidation";
import { post } from "./api/api";

const RegisterPage = () => {
  const navigate = useNavigate();
  const [passwordErrors, setPasswordErrors] = useState([]);
  const [passwordConfirmation, setPasswordConfirmation] = useState("");

  const [formData, setFormData] = useState({
    lastname: "",
    firstname: "",
    email: "",
    password: "",
    role: "Team",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const passwordErrors = validatePassword(
      formData.password,
      passwordConfirmation
    );
    setPasswordErrors(passwordErrors);

    if (passwordErrors.length > 0) {
      showToast(
        "Hiba a jelszó mezők validálása során. Kérjük, ellenőrizze a hibákat.",
        "error"
      );
      return;
    }

    try {
      await post.RegisterData(formData);
      showToast("Sikeres regisztráció!", "success");
      navigate("/");
    } catch (error) {
      showToast(
        "Hiba történt a regisztráció közben: " + error.response.data,
        "error"
      );
      console.log(error);
    }

    console.log("Form Data:", formData);
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100 py-12">
      <div className="bg-white p-12 rounded-xl shadow-2xl w-full max-w-lg">
        <h2 className="text-3xl font-bold mb-8 text-center">Regisztráció</h2>
        <form>
          <div className="mb-6">
            <label className="block text-gray-700 text-lg">Vezetéknév</label>
            <input
              type="text"
              name="lastname"
              className="w-full px-4 py-3 text-lg border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Vezetéknév"
              autoComplete="family-name"
              required
              onChange={handleChange}
              value={formData.lastname}
              id="lastname"
            />
          </div>
          <div className="mb-6">
            <label className="block text-gray-700 text-lg">Keresztnév</label>
            <input
              type="text"
              name="firstname"
              className="w-full px-4 py-3 text-lg border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Keresztnév"
              autoComplete="given-name"
              required
              onChange={handleChange}
              value={formData.firstname}
              id="firstname"
            />
          </div>
          <div className="mb-6">
            <label className="block text-gray-700 text-lg">Email</label>
            <input
              type="email"
              name="email"
              className="w-full px-4 py-3 text-lg border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Email"
              autoComplete="email"
              required
              onChange={handleChange}
              value={formData.email}
              id="email"
            />
          </div>
          <div className="mb-6">
            <label className="block text-gray-700 text-lg">Jelszó</label>
            <input
              type="password"
              name="password"
              className="w-full px-4 py-3 text-lg border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Jelszó"
              autoComplete="new-password"
              required
              onChange={handleChange}
              value={formData.password}
              id="password"
            />
          </div>
          <div className="mb-8">
            <label className="block text-gray-700 text-lg">
              Jelszó megerősítése
            </label>
            <input
              type="password"
              className="w-full px-4 py-3 text-lg border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Jelszó megerősítése"
              autoComplete="new-password"
              required
              onChange={(e) => setPasswordConfirmation(e.target.value)}
              value={passwordConfirmation}
              id="passwordConfirmation"
            />
          </div>
          {passwordErrors.length > 0 && (
            <div className="w-full mb-6">
              <p className="mb-2">Hiba a regisztráció közben:</p>
              {passwordErrors.map((error, index) => (
                <p className="text-red-500" key={index}>
                  {error}
                </p>
              ))}
            </div>
          )}
          <button
            className="w-full bg-blue-600 text-white py-3 rounded-lg font-semibold text-lg hover:bg-blue-700"
            type="submit"
            onClick={handleSubmit}
          >
            Regisztráció
          </button>
        </form>
        <p className="text-center mt-6 text-lg">
          Van már fiókod?{" "}
          <a href="/belepes" className="text-blue-600 hover:underline">
            Belépés
          </a>
        </p>
      </div>
    </div>
  );
};

export default RegisterPage;
