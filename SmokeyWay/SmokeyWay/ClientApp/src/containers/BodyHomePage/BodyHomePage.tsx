import React from "react";
import styled from "styled-components";

const StyledDivBLock = styled.div`
width: 100vw;
height: 100vh;
min-width: 100vw;
min-height: 100vh;
visibility: visible;
`;

const backgroundSmokeVideo = require("../../public/smokeBackground.webm");

function BodyHomePage()
{
    return(
        <div style={{position: "absolute", top: "1px", zIndex: -1}}>
            <StyledDivBLock>
                <video src={backgroundSmokeVideo} autoPlay muted loop style={{left: 0, right: 0, position: "absolute", objectFit: "cover", objectPosition: "center"}}/>
                <div style={{fontSize: "10vw",height:"inherit", display: "flex", justifyContent: "center", alignItems: "center"}}>
                    <h1  style={{mixBlendMode: "overlay", color: "#fff"}}>
                        Smokey Way
                    </h1>
                </div>
            </StyledDivBLock>
            <StyledDivBLock style={{backgroundColor: "black"}}>lol2</StyledDivBLock>
            <StyledDivBLock style={{backgroundColor: "pink"}}>lol</StyledDivBLock>
        </div>
    )
}
export default BodyHomePage;