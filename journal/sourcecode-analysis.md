```basic
10 DEFINT A-Z: DIM R(19,3),P(1),B(1)
20 FOR I=0 TO 19: READ R(I,0),R(I,1),R(I,2): NEXT
30 INPUT "Enter a number";X: X=RND(-ABS(X))
40 PRINT: PRINT "*** HUNT THE WUMPUS ***"
50 PRINT "-----------------------": PRINT
60 FOR I=0 TO 1: GOSUB 500: P(I)=X: GOSUB 500: B(I)=X: NEXT
70 GOSUB 500: W=X: GOSUB 500: P=X
80 A=5
90 IF A=0 THEN 340
100 IF P=W THEN 410
110 IF P=B(0) OR P=B(1) THEN 360
120 IF P=P(0) OR P=P(1) THEN 390
130 PRINT: FOR I=0 TO 2
140 IF R(P,I)=W THEN PRINT "You smell something terrible nearby."
150 FOR J=0 TO 1
160 IF R(P,I)=B(J) THEN PRINT "You hear a rustling."
170 IF R(P,I)=P(J) THEN PRINT "You feel a cold wind blowing from a nearby cavern."
180 NEXT J,I
190 PRINT USING "You are in room ##. ";P;
200 PRINT USING "Tunnels lead to ##; ##; and ##.";R(P,0);R(P,1);R(P,2)
210 PRINT USING "You have # arrows.";A: PRINT
220 LINE INPUT "M)ove, S)hoot or Q)uit? ";I$
230 S=I$="S" OR I$="s": IF S OR I$="M" OR I$="m" THEN 260
240 IF I$="Q" OR I$="q" THEN END
250 PRINT "Sorry?": GOTO 220
260 INPUT "Which room";X: PRINT
270 IF X=R(P,0) OR X=R(P,1) OR X=R(P,2) THEN IF S THEN 290 ELSE P=X: GOTO 90
280 PRINT "Cannot get there from here.": GOTO 260
290 IF X=W THEN PRINT "Congratulations! You shot the wumpus!": GOTO 440
300 PRINT "You missed.": A=A-1: IF RND(1)<.25 THEN 90
310 PRINT "The wumpus wakes from his slumber."
320 X=RND(1)*3: IF R(R(W,X),3) THEN 320
330 R(W,3)=0: W=R(W,X): R(W,3)=1: GOTO 90
340 PRINT "As you grasp at your empty quiver, ";
350 PRINT "you hear a large beast approaching...": GOTO 410
360 PRINT "You have entered the lair of a large bat."
370 PRINT "It picks you up and drops you in room";
380 P=R(P,RND(1)*3): PRINT P;".": GOTO 90
390 PRINT "The ground gives way beneath your feet."
400 PRINT "You fall into a deep abyss.": GOTO 430
410 PRINT "You find yourself face to face with the wumpus."
420 PRINT "It eats you whole."
430 PRINT: PRINT "You have met your demise."
440 LINE INPUT "Another game (Y/N)?";I$
450 IF I$="Y" OR I$="y" THEN 60
460 IF I$<>"N" AND I$<>"n" THEN PRINT "Sorry?": GOTO 440
470 END
500 X=RND(1)*20: IF R(X,3)=0 THEN R(X,3)=1: RETURN ELSE 500
510 DATA 1,4,7, 0,2,9, 1,3,11, 2,4,13, 0,3,5
520 DATA 4,6,14, 5,7,16, 0,6,8, 7,9,17, 1,8,10
530 DATA 9,11,18, 2,10,12, 11,13,19, 3,12,14, 5,13,15
540 DATA 14,16,19, 6,15,17, 8,16,18, 10,17,19, 12,15,18
```

### Analysis

> `10 DEFINT A-Z: DIM R(19,3),P(1),B(1)`

`DEFINT A-Z:`

Define all variables starting with A to Z as integers

`DIM R(19,3),P(1),B(1)`

Create an array named R with 2 dimensions of 20 by 4, and two 1D arrays called P and B.

> `20 FOR I=0 TO 19: READ R(I,0),R(I,1),R(I,2): NEXT`

`FOR I=0 TO 19: READ R(I,0),R(I,1),R(I,2):`

Read off of the array R, collecting all the data in the array.

> `30 INPUT "Enter a number";X: X=RND(-ABS(X))`

`INPUT "Enter a number";X:`

When prompted by "Enter a number", the user will enter a number and it will be stored in the variable X.

`X=RND(-ABS(X))` 

The program will generate a random negative number.

> `40 PRINT: PRINT "*** HUNT THE WUMPUS ***"`
> 
> `50 PRINT "-----------------------": PRINT`

Printing lines.

> `60 FOR I=0 TO 1: GOSUB 500: P(I)=X: GOSUB 500: B(I)=X: NEXT`

Calls a subroutine on line 500 of the program.

```basic
500 X=RND(1)*20: IF R(X,3)=0 THEN R(X,3)=1: RETURN ELSE 500
```

*The subroutine called*

> `70 GOSUB 500: W=X: GOSUB 500: P=X`

Assign the value from the previous line to W and X and call the subroutine on line 500.

> `80 A=5`
> 
> `90 IF A=0 THEN 340`

Set the arrow count for the player. If the player has 0 arrows, go to line 340.

> `100 IF P=W THEN 410`
> 
> `110 IF P=B(0) OR P=B(1) THEN 360`
> 
> `120 IF P=P(0) OR P=P(1) THEN 390`

`100 IF P=W THEN 410` 

If the player is in the same room as the Wumpus, go to line 410.

`110 IF P=B(0) OR P=B(1) THEN 360`

If the player is in the same room as a bat, go to line 360.

`120 IF P=P(0) OR P=P(1) THEN 390`

If the player is in the same room as a pit, go to line 390.

> `130 PRINT: FOR I=0 TO 2`
> 
> `140 IF R(P,I)=W THEN PRINT "You smell something terrible nearby."`
> 
> `150 FOR J=0 TO 1`
> 
> `160 IF R(P,I)=B(J) THEN PRINT "You hear a rustling."`
> 
> `170 IF R(P,I)=P(J) THEN PRINT "You feel a cold wind blowing from a nearby cavern."``

Handles being near bats or pits and tells the player if they are.

> `180 NEXT J,I`
> 
> `190 PRINT USING "You are in room ##. ";P;`
> 
> `200 PRINT USING "Tunnels lead to ##; ##; and ##.";R(P,0);R(P,1);R(P,2)`
> 
> `210 PRINT USING "You have # arrows.";A: PRINT`
> 
> `220 LINE INPUT "M)ove, S)hoot or Q)uit? ";I$`

Tells the player info: what room they are in, what rooms they may go to, and their available actions (Move, Shoot, Quit). The player inputs a letter and it is stored in the variable `I`.

> `230 S=I="S" OR I="s": IF S OR I="M" OR I="m" THEN 260`
> 
> `240 IF I="Q" OR I="q" THEN END`

Handle the player inputs. If the player would like to move or shoot (player inputs "m" or "s") then go to line 260. If the player inputs "q" (quit) then end the program.

> `250 PRINT "Sorry?": GOTO 220`

If the input is not recognised, go to line 220 and ask for the input again.

> `260 INPUT "Which room";X: PRINT`

Ask the player for an input of which room they would like to move to or shoot into.

> `270 IF X=R(P,0) OR X=R(P,1) OR X=R(P,2) THEN IF S THEN 290 ELSE P=X: GOTO 90`
> 
> `280 PRINT "Cannot get there from here.": GOTO 260`
> 
> `290 IF X=W THEN PRINT "Congratulations! You shot the wumpus!": GOTO 440`
> 
> `300 PRINT "You missed.": A=A-1: IF RND(1)<.25 THEN 90`

`270 IF X=R(P,0) OR X=R(P,1) OR X=R(P,2) THEN IF S THEN 290 ELSE P=X: GOTO 90` 

If the player has chosen to shoot, go to line 290. Also checks if the player can move/shoot into the desired room. 

`280 PRINT "Cannot get there from here.": GOTO 260`

If the player cannot move/shoot into the room, go to line 260 and repeat.

`290 IF X=W THEN PRINT "Congratulations! You shot the wumpus!": GOTO 440`

If the room inputted is the room the wumpus is in, print "Congratulations! You shot the wumpus!" and go to line 440. 

`300 PRINT "You missed.": A=A-1: IF RND(1)<.25 THEN 90`

If the room is not the room with the wumpus, the player misses and the program checks if the wumpus wakes up using a random function.

> `320 X=RND(1)*3: IF R(R(W,X),3) THEN 320`
> 
> `330 R(W,3)=0: W=R(W,X): R(W,3)=1: GOTO 90`

Handles the arrow bouncing between rooms

> Lines 340 - 430

Text tied to events and called from their correlating lines (excluding 380)

> `380 P=R(P,RND(1)*3): PRINT P;".": GOTO 90`

Handles the bats dropping the player into random rooms.

> Lines 440 >

Many of these lines are data structures or subroutines called by other lines.

> `440 LINE INPUT "Another game (Y/N)?";I`
> 
> `450 IF I="Y" OR I="y" THEN 60`
> 
> `460 IF I<>"N" AND I$<>"n" THEN PRINT "Sorry?": GOTO 440`
> 
> `470 END`

Subroutine called by line 290 if the player wins. Also comes after the section managing the player loss, effectively acting as a game over scenario.

> `510 DATA 1,4,7, 0,2,9, 1,3,11, 2,4,13, 0,3,5`
> 
> `520 DATA 4,6,14, 5,7,16, 0,6,8, 7,9,17, 1,8,10`
> 
> `530 DATA 9,11,18, 2,10,12, 11,13,19, 3,12,14, 5,13,15`
> 
> `540 DATA 14,16,19, 6,15,17, 8,16,18, 10,17,19, 12,15,18`

Contains data structures for the rooms the player can move to.
