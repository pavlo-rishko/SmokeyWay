import React from "react";
import { Link } from 'react-router-dom';
import styled from "styled-components";
import ScrollHandler from "../../components/ScrollHandler";
import Logo from '../../public/SmokeyWayLogo.svg';

const StyledLogo = styled("img")<{isScrolled: boolean}>`
  filter: ${props => props.isScrolled ? "invert(1)" : "drop-shadow(2px 4px 3px black)"};
  height: 80px;
  padding-left: 0;
  float: left;
`;

const StyledLink = styled("div")<{isScrolled: boolean}>`
  padding: 20px;
  margin: 10px;
  display: inline-block;
  border-radius: 5px;
  &:hover {
    box-shadow: 0px 0px 15px 2px  ${props => props.isScrolled ? "white" : "black"};
    color: black;
  }
  a {
    text-decoration: inherit;
    color: ${props => props.isScrolled ? "white" : "black"};
    @media (max-width: 1000px) {
     color: black;
    }
  }
`;

const StyledNav = styled("div")<{isScrolled: boolean}>`
  position: fixed;
  width: 100%;
  background-color: ${props => props.isScrolled ? "transparent " : "white"};
`;

const StyledButtonsBlockDiv = styled.div`
  @media (max-width: 1000px) {
    top: -1vh;
    width: 200px;
    border-radius: 0px 0px 0px 20px;
    position: absolute;
    background-color: white;
    right: 0;
    display: grid;
  }
`;

function Header(){
  const _isScrolled = ScrollHandler();

    return(
        <header style={{position: "relative", top: _isScrolled? "1vh" : ""}}>
            <StyledNav isScrolled={_isScrolled}>
                <StyledLogo isScrolled={_isScrolled} src={Logo}/>
                <StyledButtonsBlockDiv>
                  <StyledLink isScrolled={_isScrolled}>
                      <Link to="./">Smokey Way</Link>
                  </StyledLink>
                  <StyledLink isScrolled={_isScrolled}>
                      <Link to="./">Галерея</Link>
                  </StyledLink>
                  <StyledLink isScrolled={_isScrolled}>
                      <Link to="./">Контакти</Link>
                  </StyledLink>  
                </StyledButtonsBlockDiv>             
            </StyledNav>
        </header>
    )
}
export default Header;