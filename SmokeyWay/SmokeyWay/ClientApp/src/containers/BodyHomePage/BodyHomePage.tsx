import React from "react";
import styled from "styled-components";
import ScrollHandler from "../../components/ScrollHandler";
import SectionWipes from "../../components/SectionWipesComponent/SectionWipes";
import "./BodyHomePage.css";
import PositionMap from "../../components/PositionMapComponent/PositionMap";

const StyledDiv = styled.div`
    width: 100vw;
    height: 110vh;
    min-width: 100vw;
    min-height: 100vh;
`;

const StyledVideo = styled.video`
    min-height: 120vh;
    max-width: 100vw;
    width: 100%;
    left: 0px;
    right: 0px;
    position: absolute;
    object-fit: cover;
    object-position: center center;
`;
const StyledFlexVideoContainer = styled("div")<{isScrolled: boolean}>`
    height: 120vh;
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
            <StyledDiv style={{height: "120vh"}}>
                <StyledVideo src={backgroundSmokeVideo} autoPlay muted loop />
                <StyledFlexVideoContainer isScrolled={_isScrolled}>                    
                    <h1 style={{fontFamily:"PermanentMarker-Regular", fontSize: "12vw", mixBlendMode: "overlay", color: "#fff"}}>
                        Smokey Way
                    </h1>
                </StyledFlexVideoContainer>
            </StyledDiv>
            <SectionWipes/>
            <StyledDiv style={{backgroundColor: "black"}}>
            </StyledDiv>
            <StyledDiv  style={{backgroundColor: "pink"}}>                
                <div style={{height: "100vh", display: "flex", justifyContent: "flex-end", alignItems: "center"}}>
                    <div style={{position:"relative", right:"4vw", bottom: "5vh"}}>
                        <PositionMap zoom={18}/>
                    </div>
                </div>
            </StyledDiv>
        </div>
    )
}
export default BodyHomePage;