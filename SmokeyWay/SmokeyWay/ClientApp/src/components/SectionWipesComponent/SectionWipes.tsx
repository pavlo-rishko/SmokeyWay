import React from 'react';
import styled from 'styled-components';
import { Controller, Scene } from 'react-scrollmagic';
import { Tween, Timeline } from 'react-gsap';
import CatImg from '../../public/hookahCat.png';

const SectionWipesStyled = styled.div`
  overflow: hidden;

  #pinContainer {
    height: 100vh;
    width: 100vw;
    overflow: hidden;
  }

  #pinContainer .panel {
    height: 100vh;
    width: 100vw;
    position: absolute;
    text-align: center;
  }

  .panel {
    align-items: center;
    justify-content: center;
    display: flex;
  }
    
  .panel.black {
    background-color: black;
  }

  .panel.white {
    background-color: white;
  }
`;

const SectionWipes = () => (
  <SectionWipesStyled>
    <Controller>
      <Scene
        triggerHook="onLeave"
        duration="500%"
        pin
      >
        <Timeline wrapper={<div id="pinContainer" />}>
          <section className="panel black">
                  <img src={CatImg}/>
          </section>
          <Tween from={{ x: '-400%' }} to={{ x: '0%' }}>
            <section className="panel white">
                    LOL2
            </section>
          </Tween>
          <Tween from={{ x: '150%' }} to={{ x: '0%' }}>
            <section className="panel black">
                    LOL3
            </section>
          </Tween>
          <Tween from={{ y: '-150%' }} to={{ y: '0%' }}>
            <section className="panel white">
                    LOL4
            </section>
          </Tween>
        </Timeline>
      </Scene>
    </Controller>
  </SectionWipesStyled>
);

export default SectionWipes;
