import { Toaster } from "react-hot-toast";
import "./App.css";
import AuthProvider from "./Components/Auth/Auth";
import Routes from "./Components/Routes/Routes";

function App() {
  return (
    <AuthProvider>
      <Toaster />
      <Routes />
    </AuthProvider>
  );
}

export default App;
