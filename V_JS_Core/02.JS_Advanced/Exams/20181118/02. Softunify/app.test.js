const SoftUniFy = require('./app');
const assert = require('chai').assert;

describe('SoftUniFy', function () {

    let softunify;
    beforeEach(() => {
        softunify = new SoftUniFy();
    });

    let artist = 'Bon Jovi';
    let song = 'These days';
    let lyrics = 'I was walking around, just a face in the crowd ...';


    it('should return correct object', function () {
        let expectedResult = {
            'allSongs': {
                'Bon Jovi':
                {
                    rate: 0,
                    votes: 0,
                    songs: [`${song} - ${lyrics}`]
                }
            }
        };

        assert.deepEqual(softunify.downloadSong(artist, song, lyrics), expectedResult);
    });

    it('with not existing song, should return message', function () {
        softunify.downloadSong(artist, song, lyrics);

        let result = softunify.playSong('Little city');
        let expectedResult = `You have not downloaded a Little city song yet. Use SoftUniFy's function downloadSong() to change that!`;

        assert.equal(result, expectedResult);
    });

    it('with not existing artist should return message', function () {
        softunify.downloadSong(artist, song, lyrics);

        let result = softunify.rateArtist('ZAZ');
        let expectedResult = `The ZAZ is not on your artist list.`;

        assert.equal(result, expectedResult);
    });
});