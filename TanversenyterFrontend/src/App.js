import "./App.css";
import AuthProvider from "./Components/Auth/Auth";
import Routes from "./Components/Routes/Routes";

function App() {
  return (
    <AuthProvider>
      <Routes></Routes>
    </AuthProvider>
  );
}

export default App;
