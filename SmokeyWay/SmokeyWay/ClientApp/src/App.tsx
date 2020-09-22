import React from "react";
import Header from "./containers/Header/Header";
import "./App.css";
import { BrowserRouter } from "react-router-dom";
import BackgroundMusicPlayer from "./components/BackgroundMusicPlayer";

function App() {
  return (
    <BrowserRouter>
        <div className="App">
          <Header></Header>
          <BackgroundMusicPlayer uniqueId="offyou.mp3" songPath="../public/offyou.mp3"></BackgroundMusicPlayer>
        </div>
    </BrowserRouter>
  );
}

export default App;
