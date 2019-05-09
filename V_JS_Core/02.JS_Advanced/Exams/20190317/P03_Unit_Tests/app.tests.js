const FilmStudio = require('./app');
const assert = require('chai').assert;

describe('FilmStudio', function(){
    let filmStudio;
    beforeEach(() => {
        filmStudio = new FilmStudio('bla-bla');
    });

    describe('constructor', function(){       
        it('should contain empty films array', function(){
            assert.equal(filmStudio.films.length, 0);
        })
    });

    describe('casting', function(){       
        it('with no films', function(){
            let result = filmStudio.casting('me', 'me');
            assert.equal(result, 'There are no films yet in bla-bla.');
        });

        it('witn unemployed actor', function(){
            filmStudio.makeMovie('me', ['roles']);
            let actor = 'actor';
            let role = 'role';
            assert.equal(filmStudio.casting(actor, role), `${actor}, we cannot find a ${role} role...`);
        });

        it('with valid output', function(){
            filmStudio.makeMovie('me', ['killer']);
            let actor = 'actor';
            let role = 'killer';

            assert.equal(filmStudio.casting(actor, role), `You got the job! Mr. ${actor} you are next ${role} in the me. Congratz!`);
        });
    });

    describe('makeMovie', function(){       
        it('with invalid arguments count', function(){
            assert.throw(()=>filmStudio.makeMovie('role'), 'Invalid arguments count');
        });

        it('with invalid arguments types', function(){
            assert.throw(()=>filmStudio.makeMovie(1, ['female']), 'Invalid arguments');
            assert.throw(()=>filmStudio.makeMovie('me', 'me'), 'Invalid arguments');
            assert.throw(()=>filmStudio.makeMovie(1, 'me'), 'Invalid arguments');
        });
    });

    describe('lookForProducer', function(){       
        it('with invalid filmname', function(){
            filmStudio.makeMovie('filmName', ['roles']);
            let film = 'film';
            assert.throw(()=>filmStudio.lookForProducer(film), `${film} do not exist yet, but we need the money...`);
        });

        it('with invalid output', function(){
            filmStudio.makeMovie('film', ['killer', 'victim']);
            filmStudio.casting('me', 'killer');
            filmStudio.casting('someone', 'victim');
            let film = 'film';
            let result = 'Film name: film\n' +
                        'Cast:\n'+
                        'me as killer\n'+
                        'someone as victim\n';
            
            assert.equal(filmStudio.lookForProducer(film), result);
        });
    });
})