import { orbitron } from '../fonts'
import './_main-info.scss'
import classNames from 'classnames'
import InfoDesc from '../Components/InfoDesc/InfoDesc'
import gamingKeyboard from '../assets/img/gaming-keyboard.jpg'
import LaptopImage from '../assets/img/Laptop.png'
import Image from 'next/image'
import WorldChampionship from '../assets/img/world-championship.png'



const cn = classNames;

// Hacer que las paginas después de main info scrolleen automáticamente

export default function MainInfo()
{
  return(
    <>
    <section className='main-info-wrapper'>
      <h1 className={cn('main-info-title', orbitron.className)}>¡FORJANDO LEYENDAS EN CADA LUGAR!</h1>
      <p className={cn('main-info-desc')}>Participa en el primer torneo de NOVA para poner a prueba tus conocimientos sobre la computación y ganar recompensas increíbles</p>
    </section>
    <InfoDesc descImg={gamingKeyboard} descTitle='NOVA eSPORTS LEAGUE' descInfo='Es un proyecto innovador creado con el propósito de despertar el potencial de la tecnología y la informática en los jóvenes estudiantes apasionados por los eSports, así como elevar su nivel competitivo global.' />

    <InfoDesc descImg={LaptopImage} descTitle='PROGRAMA DE DESAROLLO DE TALENTO NOVA' descInfo='Iniciativa que busca descubrir y potenciar el talento en los eSports, en donde la adquisición de conocimientos que influyen en el desarrollo personal y académico de cada uno de los participantes, pertenecientes al estado Zulia, prevalezca.' inverted>
    <a href='#' className='see-more-btn'>Ver más</a>
    </InfoDesc>
    <Image src={WorldChampionship} alt='nova world championship'/>
    <section className='wc-wrapper'>
      <div className='wc-text'>
        <h3 className={cn('wc-text', 'wc-text__title')}>COPA TRUENO</h3>
        <p className={cn('wc-text', 'wc-text__info')}>Un evento de juego competitivo donde los participantes tendrán que poner en práctica los conocimientos adquiridos previos al campeonato y demostrar sus habilidades de juego para ser el mejor equipo y recibir una recompensa. La misma será realizada los días <strong>12, 13 y 14 de julio</strong> de este año 2024</p>
      </div>
    </section>
    </>
  )
}