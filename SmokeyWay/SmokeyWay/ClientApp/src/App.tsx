import React from "react";
import Header from "./containers/Header/Header";
import "./App.css";
import { BrowserRouter } from "react-router-dom";
import BackgroundMusicPlayer from "./components/BackgroundMusicPlayer";
import BodyHomePage from "./containers/BodyHomePage/BodyHomePage";

function App() {
  const backgroungSong = require("./public/offyou.mp3");
  return (
    <BrowserRouter>
        <div className="App">
          <Header/>
          <BodyHomePage/>
          <BackgroundMusicPlayer uniqueId="offyou.mp3" songPath={backgroungSong}/>
        </div>
    </BrowserRouter>
  );
}

export default App;
