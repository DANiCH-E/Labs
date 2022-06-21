//Маршрутизация
import React from "react";
import { useContext } from "react";
import { Navigate, Route, Routes } from "react-router-dom";
import { AuthContext } from "../context";
import About from "../pages/About";
import Error from "../pages/Error";
import PostIdPage from "../pages/PostIdPages";
import Posts from "../pages/Posts";
import { privateRoutes, publicRoutes, routes } from "../router/routes";
import Loader from "./UI/Loader/Loader";

const AppRouter = () => {
    const {isAuth, isLoading} = useContext(AuthContext);
    console.log(isAuth)

    if (isLoading) {
      return <Loader/>
    }

    return (
        isAuth
        ?
        <Routes>
          {privateRoutes.map(route =>
            <Route 
              element={<route.Element/>} 
              path={route.path}
              key={route.path}
            />
          )}
          <Route
            path='*'
            element={<Navigate to="/posts" replace/>}
          />
        </Routes>
        :
        <Routes>
          {publicRoutes.map(route =>
            <Route 
              element={<route.Element/>} 
              path={route.path}
              key={route.path} 
            />
          )}
          <Route
            path='*'
            element={<Navigate to="/login" replace/>}
          />
        </Routes>
        
      
    )
}

export default AppRouter;