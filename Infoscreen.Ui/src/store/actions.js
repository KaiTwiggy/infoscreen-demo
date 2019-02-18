import * as types from './mutationtypes'

export const updateSlides = ({ commit }, slides) => {
  commit(types.SLIDES_UPDATE, {
    slides
  })
}
