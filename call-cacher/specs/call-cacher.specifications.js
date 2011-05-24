describe("Call cacher specifications", function () {

    var PersonClient;

    beforeEach(function () {

        PersonClient = function () {
            this.value = '.';
            new CallCacher().applyCacheToCall('getNames', this);
        };

        PersonClient.prototype.getNames = function (beginWith) {
            var date = new Date().getMilliseconds()
            return [{ time: date, text: beginWith + this.value}];
        };

    });

    describe("when a clean call is made", function () {
        it("should use the correct this in the wrapped call", function () {
            var personClient = new PersonClient();
            var data1 = personClient.getNames('a');
            expect(data1[0].text).toEqual('a.');
        });
    });

    describe("when a call is made with the same parameters", function () {
        it("should cache the first call and use it in the second call", function () {
            var personClient,
            data1,
            data2;

            runs(function () {
                personClient = new PersonClient();
                data1 = personClient.getNames('a');
            });

            waits(1);

            runs(function () {
                data2 = personClient.getNames('a');

                expect(data1[0].time).toEqual(data2[0].time);
                expect(data1[0].text).toEqual(data2[0].text);
            });
        });
    });

    describe("when a call is made with different parameters value", function () {
        it("should not cache anything", function () {
            var personClient,
            data1,
            data2;

            runs(function () {
                personClient = new PersonClient();
                data1 = personClient.getNames('a');
            });

            waits(1);

            runs(function () {
                data2 = personClient.getNames('b');

                expect(data1[0].time).not.toEqual(data2[0].time);
            });
        });
    });

    describe("when a call is made with different numbers of parameters", function () {
        it("should not cache anything", function () {
            var personClient,
            data1,
            data2;

            runs(function () {
                personClient = new PersonClient();
                data1 = personClient.getNames('a');
            });

            waits(1);

            runs(function () {
                data2 = personClient.getNames('a', 'b');

                expect(data1[0].time).not.toEqual(data2[0].time);
            });
        });
    });

});

