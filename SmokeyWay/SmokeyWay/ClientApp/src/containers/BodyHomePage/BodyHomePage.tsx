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

const StyledPositionMapWrapDiv = styled.div`
    height: 100vh;
    display: flex;
    justify-content: flex-end;
    padding-right: 6vw;
    padding-bottom: 4vh;
    align-items: center;
    @media (max-width: 800px) {
        justify-content: center;
        padding-right: 0;
    }
`;

const StyledH1Logo = styled.h1`
    font-family: PermanentMarker-Regular;
    font-size: 12vw;
    mix-blend-mode: overlay;
    color: #fff;
    @media (max-width: 800px) {
        line-height: 200px;
        font-size: 20vw;
        word-break: break-word;
    }
    @media (max-width: 650px) {
        line-height: 25vw;
        font-size: 25vw;
    }
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
                    <StyledH1Logo>
                        Smokey Way
                    </StyledH1Logo>
                </StyledFlexVideoContainer>
            </StyledDiv>
            <SectionWipes/>
            <StyledDiv style={{backgroundColor: "black"}}>
            </StyledDiv>
            <StyledDiv  style={{backgroundColor: "pink"}}>                
                <StyledPositionMapWrapDiv>
                        <PositionMap zoom={18}/>
                </StyledPositionMapWrapDiv>
            </StyledDiv>
        </div>
    )
}
export default BodyHomePage;