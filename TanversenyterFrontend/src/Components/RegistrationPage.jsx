import React from "react";

const RegisterPage = () => {
  return (
    <div className="h-screen flex items-center justify-center bg-gray-100">
      <div className="bg-white p-8 rounded-lg shadow-lg w-96">
        <h2 className="text-2xl font-bold mb-6 text-center">Regisztráció</h2>
        <form>
          <div className="mb-4">
            <label className="block text-gray-700">Email</label>
            <input
              type="email"
              className="w-full px-4 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Enter your email"
            />
          </div>
          <div className="mb-6">
            <label className="block text-gray-700">Jelszó</label>
            <input
              type="password"
              className="w-full px-4 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Jelszó"
            />
          </div>
          <div className="mb-6">
            <label className="block text-gray-700">Jelszó megerősítése</label>
            <input
              type="password"
              className="w-full px-4 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-600"
              placeholder="Jelszó megerősítése"
            />
          </div>
          <button className="w-full bg-blue-600 text-white py-2 rounded-lg font-semibold hover:bg-blue-700">
            Register
          </button>
        </form>
        <p className="text-center mt-4">
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
