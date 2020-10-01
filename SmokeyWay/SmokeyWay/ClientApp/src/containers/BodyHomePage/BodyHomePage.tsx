import React from "react";
import styled from "styled-components";
import ScrollHandler from "../../components/ScrollHandler";
import "./BodyHomePage.css";

const StyledDiv = styled.div`
width: 100vw;
height: 100vh;
min-width: 100vw;
min-height: 100vh;
visibility: visible;
`;

const StyledVideo = styled.video`
    min-height: 110vh;
    max-width: 100%;
    left: 0px;
    right: 0px;
    position: absolute;
    object-fit: cover;
    object-position: center center;
`;
const StyledFlexVideoContainer = styled("div")<{isScrolled: boolean}>`
    height: 110vh;
    display: flex;
    justify-content: center;
    align-items: center;
    padding-top: ${props => props.isScrolled ? "8vh" : "initial"};
`;

const backgroundSmokeVideo = require("../../public/smokeBackground.webm");

function BodyHomePage()
{
    const _isScrolled = ScrollHandler();

    return(
        <div style={{position: "absolute", top: "1px", zIndex: -1}}>
            <StyledDiv>
                <StyledVideo src={backgroundSmokeVideo} autoPlay muted loop />
                <StyledFlexVideoContainer isScrolled={_isScrolled}>                    
                    <h1 style={{fontFamily:"PermanentMarker-Regular", fontSize: "12vw", mixBlendMode: "overlay", color: "#fff"}}>
                        Smokey Way
                    </h1>
                </StyledFlexVideoContainer>
            </StyledDiv>
            <StyledDiv style={{backgroundColor: "black"}}>lol2</StyledDiv>
            <StyledDiv style={{backgroundColor: "pink"}}>lol</StyledDiv>
        </div>
    )
}
export default BodyHomePage;