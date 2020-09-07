import React from "react";
import Header from "./containers/Header/Header";
import "./App.css";
import { BrowserRouter } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
        <div className="App">
          <Header></Header>
        </div>
    </BrowserRouter>
  );
}

export default App;
