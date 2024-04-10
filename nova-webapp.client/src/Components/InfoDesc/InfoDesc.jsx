import Image from 'next/image';
import classNames from 'classnames';
import styles from './_info-desc.module.scss'

const cn = classNames;

export default function InfoDesc(props)
{

  return (
    <>
    <section className='nova-desc-wrapper'>
    <div className={cn('nova-desc', `nova-desc--${(props.inverted) && 'inverted'}`)}>
    <Image
      src={props.descImg}
      alt='nova-eSports league'
      className={cn('nova-desc', 'nova-desc__img')}
    />
    <div className="nova-desc-l"></div>
      <div className={cn('nova-desc', 'nova-desc__text')}>
        <h3>{props.descTitle}</h3>
        <p>{props.descInfo}</p>
      </div>
    </div>
      {props.children}
    </section>
    </>
  )
}