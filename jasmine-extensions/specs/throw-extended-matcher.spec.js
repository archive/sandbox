
describe("Extended toThrow matcher specifications", function(){

    beforeEach(function() {
      this.addMatchers({
        toThrowWithMessageContaining : function(expected) {
          var result = false;
          var exception;
          if (typeof this.actual != "function") {
            throw new Error("Actual is not a function");
          }
          if (typeof expected === "undefined") {
            throw new Error("expected must be defined");
          }
          try {
            this.actual();
          } catch (e) {
            exception = e;
          }
          if (exception) {
            var message = exception.message || exception;
            result = message.indexOf(expected) !== -1
          }
        
          var not = this.isNot ? "not " : "";
        
          this.message = function() {
            if (exception && (expected === jasmine.undefined || !this.env.equals_(exception.message || exception, expected.message || expected))) {
              return ["Expected function " + not + "to throw '", expected ? expected.message || expected : "' an exception", ", but it threw'", exception.message || exception, "'"].join(' ');
            } else {
              return "Expected function to throw an exception.";
            }
          };
        
          return result;
        }
      })
    });

    describe("when an function throws an error", function(){

        var functionThatTrows;
            
        beforeEach(function(){
            functionThatTrows = function(){
                throw "this throws with a funny message";
            }  
        });
        
        it("should be possible to expect throws by saying what the throw message should have contain", function(){
            expect(functionThatTrows).toThrowWithMessageContaining("funny"); 
        });
        
        it("should be possible to expect throws by saying what the throw message should have been", function(){
            expect(functionThatTrows).toThrow("this throws with a funny message");
        });
        
    });
    
});