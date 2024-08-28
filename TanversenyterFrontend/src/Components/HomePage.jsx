import React from "react";
import "./HomePage.css";

const HomePage = () => {
  return (
    <div className="relative h-screen">
      {/* Hero Section */}
      <section className="relative h-full">
        <div className="overlay">
          <div className="content">
            <h1 className="text-5xl font-bold mb-4">
              Üdvözlünk a Taniroda Verseny Térben!
            </h1>
            <p className="text-xl mb-8">
              Tudjon meg többet szolgáltatásunkról.
            </p>
            <button className="bg-white text-blue-600 py-2 px-6 rounded-lg font-semibold hover:bg-gray-200">
              Tovább
            </button>
          </div>
        </div>
      </section>

      {/* Features Section */}
      <section className="py-16 bg-gray-100">
        <div className="container mx-auto text-center">
          <h2 className="text-3xl font-bold mb-8">Szolgáltatásaink</h2>
          <div className="flex flex-wrap justify-center">
            <div className="bg-white shadow-md rounded-lg p-6 m-4 w-80">
              <h3 className="text-xl font-semibold mb-2">Szolgáltatás 1</h3>
              <p className="text-gray-600">Szolgáltatás 1 leírása</p>
            </div>
            <div className="bg-white shadow-md rounded-lg p-6 m-4 w-80">
              <h3 className="text-xl font-semibold mb-2">Szolgáltatás 2</h3>
              <p className="text-gray-600">Szolgáltatás 2 leírása</p>
            </div>
            <div className="bg-white shadow-md rounded-lg p-6 m-4 w-80">
              <h3 className="text-xl font-semibold mb-2">Szolgáltatás 3</h3>
              <p className="text-gray-600">Szolgáltatás 3 leírása</p>
            </div>
          </div>
        </div>
      </section>

      {/* Footer */}
      <footer className="bg-blue-600 text-white py-4 text-center">
        <p>&copy; 2024 TanirodaVersenyTer. Minden jog fenntartva.</p>
      </footer>
    </div>
  );
};

export default HomePage;
