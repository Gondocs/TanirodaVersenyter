import { RouterProvider, createBrowserRouter } from "react-router-dom";
import { useAuth } from "../Auth/Auth";
import { ProtectedRoute } from "./ProtectedRoute";
import Navbar from "../Navbar";
import HomePage from "../HomePage";
import LoginPage from "../LoginPage";
import RegisterPage from "../RegistrationPage";

const Routes = () => {
  const { token } = useAuth();

  // Define public routes accessible to all users
  const routesForPublic = [
    {
      path: "/",
      element: (
        <div>
          <Navbar /> <HomePage />
        </div>
      ),
    },
    {
      path: "/*",
      element: (
        <div>
          <Navbar /> {/*<PageNotFound />*/}
        </div>
      ),
    },
  ];

  // Define routes accessible only to authenticated users
  const routesForAuthenticatedOnly = [
    {
      path: "/",
      element: <ProtectedRoute rolesAllowed={["Admin", "Team"]} />, // Wrap the component in ProtectedRoute
      children: [],
    },
    {
      /*{
      path: "/admin",
      element: <ProtectedRoute rolesAllowed={["admin"]} />, // Only admins can access this route
      children: [
        {
          path: "",
          element: (
            <>
              <Navbar /> <AdminPage />
            </>
          ),
        },
        {
          path: "users",
          element: <Navbar />,
          children: [
            {
              path: "",
              element: <Navbar />,
            },
            {
              path: "add",
              element: <Navbar />,
            },
            {
              path: "edit/:userId",
              element: <Navbar />,
            },
          ],
        },
      ],
    },*/
    },
  ];

  // Routes accessible only to non-authenticated users
  const routesForNotAuthenticatedOnly = [
    {
      path: "/belepes",
      element: (
        <div>
          <Navbar /> <LoginPage />
        </div>
      ),
    },
    {
      path: "/regisztracio",
      element: (
        <div>
          <Navbar /> <RegisterPage />
        </div>
      ),
    },
  ];

  // Combine and conditionally include routes based on authentication status
  const router = createBrowserRouter([
    ...routesForPublic,
    ...(!token ? routesForNotAuthenticatedOnly : []),
    ...routesForAuthenticatedOnly,
  ]);

  // Provide the router configuration using RouterProvider
  return <RouterProvider router={router} />;
};

export default Routes;
