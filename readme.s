;this assembler's format is as follows:
;case insensitive labels and variables
;labels end with colon
;labels and variables only alphanumeric, cannot start with numeric
;*=$val to set pc
;examples:

* = $12FF ;set the pc
starthearts:
HEARTS = $FF
LDA HEARTS
NEWHEARTS = #$04
INA
TAY
LDA NEWHEARTS
TAX
... ... ...

BNE otherplace
JMP starthearts