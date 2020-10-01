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
  }
`;

const StyledNav = styled("div")<{isScrolled: boolean}>`
  position: fixed;
  width: 100%;
  background-color: ${props => props.isScrolled ? "transparent " : "rgb(255,255,254)"};
`;
  
function Header(){
  const _isScrolled = ScrollHandler();

    return(
        <header style={{overflowAnchor: "initial"}}>
            <StyledNav isScrolled={_isScrolled}>
                <StyledLogo isScrolled={_isScrolled} src={Logo}></StyledLogo>
                <StyledLink isScrolled={_isScrolled}>
                    <Link to="./">Smokey Way</Link>
                </StyledLink>
                <StyledLink isScrolled={_isScrolled}>
                    <Link to="./">Головна</Link>
                </StyledLink>
                <StyledLink isScrolled={_isScrolled}>
                    <Link to="./">Меню</Link>
                </StyledLink>
            </StyledNav>
        </header>
    )
}
export default Header;